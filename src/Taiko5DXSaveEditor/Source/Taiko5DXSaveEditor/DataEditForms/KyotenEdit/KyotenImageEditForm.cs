using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DDS;
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor.DataEditForms.KyotenEdit
{
    /// <summary>
    /// 拠点画像を設定するフォーム
    /// </summary>
    public partial class KyotenImageEditForm : DataEditForm
    {
        #region 定数
        /// <summary>
        /// 拠点画像のフォルダのパス
        /// </summary>
        private static readonly string IMAGE_DIRECTORY_PATH = @"Image/Kyoten/";

        #endregion

        #region フィールド
        /// <summary>
        /// 編集対象の拠点（城or町）リスト
        /// </summary>
        private List<Kyoten> _KyotenEditList = new List<Kyoten>();

        /// <summary>
        /// 読み込んだ画像リスト
        /// </summary>
        private List<Image> _ImageList = new List<Image>();

        /// <summary>
        /// 拠点の種類
        /// </summary>
        private Type _KyotenType = typeof(Kyoten);

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public KyotenImageEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="selectedIDs">選択されたデータのID</param>
        /// <param name="gameData">ゲームデータ</param>
        public KyotenImageEditForm(int[] selectedIDs, GameData gameData)
            : base(selectedIDs, gameData)
        {
            // 編集対象の拠点を全て受け取る
            var kyotens = from kyoten in gameData.KyotenList
                         where selectedIDs.Contains(kyoten.ID)
                         select kyoten;
            _KyotenEditList.AddRange(kyotens);

            // コンポーネントの初期化
            InitializeComponent();

            // 拠点が城か町か
            _KyotenType = _KyotenEditList[0].GetType();
            if (_KyotenType == typeof(Shiro))
            {
                Text = @"城" + Text;
            }
            else
            {
                Text = @"町" + Text;
            }
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// フォームがロードされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void KyotenImageEditForm_Load(object sender, EventArgs e)
        {
            _KyotenImageComboBox.Tag = false;

            // コンボボックスの作成
            var nameList = _GameData.NameListDictionary["KyotenImage"];
            int n = nameList.Count;
            for (int i = 0; i < n; ++i)
            {
                // 城は5bit分のデータしかない
                if ((i > 31) && (_KyotenEditList[0] is Shiro))
                {
                    break;
                }
                _KyotenImageComboBox.Items.Add(nameList[i]);
            }

            // 拠点画像の読み込み
            for (int i = 0; i <= 38; ++i)
            {
                string fileName = i + ".dds";
                string filePath = IMAGE_DIRECTORY_PATH + fileName;
                if (!File.Exists(filePath))
                {
                    _ImageList.Add(null);
                    continue;
                }
                var ddsImage = DDSImage.Load(filePath);
                _ImageList.Add(ddsImage.Images[0]);
            }

            // 初期値の設定
            byte image = (byte)_KyotenType.GetProperty("Image").GetValue(_KyotenEditList[0]);
            bool notMatchedImage = false;
            int nedits = _KyotenEditList.Count;
            for (int i = 1; i < nedits; ++i)
            {
                if (image != (byte)_KyotenType.GetProperty("Image").GetValue(_KyotenEditList[i]))
                    notMatchedImage = true;
            }
            if (!notMatchedImage)
                _KyotenImageComboBox.SelectedIndex = image;
        }

        /// <summary>
        /// コンボボックスの選択が変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _KyotenImageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = _KyotenImageComboBox.SelectedIndex;
            _KyotenImagePictureBox.Image = _ImageList[index];

            _KyotenImageComboBox.Tag = true;
        }

        /// <summary>
        /// OKボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _OKButton_Click(object sender, EventArgs e)
        {
            bool isDataEdited = false;

            // UIから入力内容を読み取る
            byte image = 0;
            try
            {
                if ((bool)_KyotenImageComboBox.Tag)
                {
                    image = (byte)_KyotenImageComboBox.SelectedIndex;
                    isDataEdited = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, @"不正な入力が含まれています。内容を修正するか、一度このウィンドウを閉じてください。", @"エラー通知", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                _CloseCancelFlag = true;
                return;
            }

            // 変更がなければ閉じる
            if (!isDataEdited)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            // 変更を反映
            int n = _KyotenEditList.Count;
            for (int i = 0; i < n; ++i)
            {
                if ((bool)_KyotenImageComboBox.Tag)
                {
                    _KyotenType.GetProperty("Image").SetValue(_KyotenEditList[i], image);
                }
            }

            // 画面を閉じる
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// キャンセルボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _CancelButton_Click(object sender, EventArgs e)
        {
            // 画面を閉じる
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

    }
}
