using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taiko5DXSaveEditor.DataEditForms
{
    /// <summary>
    /// 画像選択フォーム
    /// </summary>
    public partial class ImageSelectForm : Form
    {
        #region プロパティ
        /// <summary>
        /// 選択した画像のインデックス
        /// </summary>
        public int SelectedImageIndex { get; set; } = -1;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public ImageSelectForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="imageWidth">画像幅</param>
        /// <param name="imageHeight">画像高さ</param>
        /// <param name="images">画像</param>
        /// <param name="names">名前</param>
        /// <param name="index">初期選択</param>
        public ImageSelectForm(int imageWidth, int imageHeight, Image[] images, string[] names, int index)
        {
            InitializeComponent();

            // 無かった時のためのダミー作成
            Bitmap dummy = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(dummy);
            g.FillRectangle(Brushes.Black, 0, 0, imageWidth, imageHeight);
            g.Dispose();

            // 画像セット
            _ImageList.ImageSize = new Size(imageWidth, imageHeight);
            for (int i = 0; i < images.Length; ++i)
            {
                if (images[i] != null)
                    _ImageList.Images.Add(images[i]);
                else
                    _ImageList.Images.Add(dummy);
                _ImageListView.Items.Add(names[i], i);
            }
            _ImageListView.Items[index].Focused = true;
            _ImageListView.Items[index].Selected = true;
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// ダブルクリックされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>ram>
        private void _ImageListView_DoubleClick(object sender, EventArgs e)
        {
            if (_ImageListView.SelectedItems.Count <= 0) return;

            int index = _ImageListView.SelectedItems[0].Index;
            SelectedImageIndex = index;

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Enterキーが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _ImageListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (_ImageListView.SelectedItems.Count <= 0) return;

            if (e.KeyCode == Keys.Enter)
            {
                int index = _ImageListView.SelectedItems[0].Index;
                SelectedImageIndex = index;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion
    }
}
