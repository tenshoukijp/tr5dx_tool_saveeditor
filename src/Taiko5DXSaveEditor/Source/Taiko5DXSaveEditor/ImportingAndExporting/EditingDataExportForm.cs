using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taiko5DXSaveEditor.GameObjects;
using Taiko5DXSaveEditor.TableManagement;

namespace Taiko5DXSaveEditor.ImportingAndExporting
{
    /// <summary>
    /// 編集データエクスポートのフォーム
    /// </summary>
    public partial class EditingDataExportForm : Form
    {
        #region フィールド
        /// <summary>
        /// ゲームデータ
        /// </summary>
        private GameData _GameData;

        /// <summary>
        /// ゲームオブジェクトリスト
        /// </summary>
        private List<GameObject> _GameObjectList = new List<GameObject>();

        /// <summary>
        /// テーブルの種類
        /// </summary>
        private TableType _TableType;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// Visual Studio UI エディタ用のコンストラクタ。
        /// 実際のアプリ上では使わない。
        /// </summary>
        public EditingDataExportForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 実際に使われるコンストラクタ
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        /// <param name="selectedRows">選択されている行</param>
        /// <param name="tableType">テーブルの種類</param>
        public EditingDataExportForm(GameData gameData, IEnumerable<DataGridViewRow> selectedRows, TableType tableType)
        {
            // コンポーネントの初期化
            InitializeComponent();

            // エクスポートデータの取得
            _GameData = gameData;
            _TableType = tableType;
            switch (_TableType)
            {
                case TableType.World:
                    _GameObjectList.Add(_GameData.World);
                    break;
                case TableType.Shujinko:
                    _GameObjectList.Add(_GameData.Shujinko);
                    break;
                case TableType.Busho:
                case TableType.GeneralPurpose:
                case TableType.EventPerson:
                case TableType.Citizen:
                    foreach (var row in selectedRows)
                    {
                        int id = (int)row.Cells["ID"].Value;
                        var obj = _GameData.BushoList[id];
                        _GameObjectList.Add(obj);
                    }
                    break;
                case TableType.Daimyoke:
                case TableType.Shoka:
                case TableType.NinjaShu:
                case TableType.KaizokuShu:
                    foreach (var row in selectedRows)
                    {
                        int id = (int)row.Cells["ID"].Value;
                        var obj = _GameData.SeiryokuList[id];
                        _GameObjectList.Add(obj);
                    }
                    break;
                case TableType.Shiro:
                case TableType.Machi:
                case TableType.Sato:
                case TableType.Toride:
                    foreach (var row in selectedRows)
                    {
                        int id = (int)row.Cells["ID"].Value;
                        var obj = _GameData.KyotenList[id];
                        _GameObjectList.Add(obj);
                    }
                    break;
                case TableType.NormalItem:
                case TableType.CraftItem:
                    foreach (var row in selectedRows)
                    {
                        int id = (int)row.Cells["ID"].Value;
                        var obj = _GameData.ItemList[id];
                        _GameObjectList.Add(obj);
                    }
                    break;
                case TableType.Hanro:
                    foreach (var row in selectedRows)
                    {
                        int id = (int)row.Cells["ID"].Value;
                        var obj = _GameData.HanroList[id];
                        _GameObjectList.Add(obj);
                    }
                    break;
                case TableType.Shoken:
                    foreach (var row in selectedRows)
                    {
                        int id = (int)row.Cells["ID"].Value;
                        var obj = _GameData.ShokenList[id];
                        _GameObjectList.Add(obj);
                    }
                    break;
                case TableType.Ryuha:
                    foreach (var row in selectedRows)
                    {
                        int id = (int)row.Cells["ID"].Value;
                        var obj = _GameData.RyuhaList[id];
                        _GameObjectList.Add(obj);
                    }
                    break;
                case TableType.Kani:
                    foreach (var row in selectedRows)
                    {
                        int id = (int)row.Cells["ID"].Value;
                        var obj = _GameData.KaniList[id];
                        _GameObjectList.Add(obj);
                    }
                    break;
            }
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// フォームがロードされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void EditingDataExportForm_Load(object sender, EventArgs e)
        {
            // チェックリストの作成
            switch (_TableType)
            {
                case TableType.World:
                    InitCheckedListForWorld();
                    break;
                case TableType.Shujinko:
                    InitCheckedListForShujinko();
                    break;
                case TableType.Busho:
                    InitCheckedListForBusho();
                    break;
                case TableType.GeneralPurpose:
                    InitCheckedListForGeneralPurpose();
                    break;
                case TableType.EventPerson:
                    InitCheckedListForEventPerson();
                    break;
                case TableType.Citizen:
                    InitCheckedListForCitizen();
                    break;
                case TableType.Daimyoke:
                    InitCheckedListForDaimyoke();
                    break;
                case TableType.Shoka:
                    InitCheckedListForShoka();
                    break;
                case TableType.NinjaShu:
                    InitCheckedListForNinjaShu();
                    break;
                case TableType.KaizokuShu:
                    InitCheckedListForKaizokuShu();
                    break;
                case TableType.Shiro:
                    InitCheckedListForShiro();
                    break;
                case TableType.Machi:
                    InitCheckedListForMachi();
                    break;
                case TableType.Sato:
                    InitCheckedListForSato();
                    break;
                case TableType.Toride:
                    InitCheckedListForToride();
                    break;
                case TableType.NormalItem:
                    InitCheckedListForNormalItem();
                    break;
                case TableType.CraftItem:
                    InitCheckedListForCraftItem();
                    break;
                case TableType.Hanro:
                    InitCheckedListForHanro();
                    break;
                case TableType.Shoken:
                    InitCheckedListForShoken();
                    break;
                case TableType.Ryuha:
                    InitCheckedListForRyuha();
                    break;
                case TableType.Kani:
                    InitCheckedListForKani();
                    break;
                default:
                    Close();
                    break;
            }
        }

        /// <summary>
        /// チェックリストのコンテキストメニューで「全チェック」がクリックされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _ContextMenu_All_Click(object sender, EventArgs e)
        {
            int n = _PropertiesCheckedListBox.Items.Count;
            for (int i = 0; i < n; ++i)
            {
                _PropertiesCheckedListBox.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// チェックリストのコンテキストメニューで「全解除」がクリックされた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _ContextMenu_Clear_Click(object sender, EventArgs e)
        {
            int n = _PropertiesCheckedListBox.Items.Count;
            for (int i = 0; i < n; ++i)
            {
                _PropertiesCheckedListBox.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// OKボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void _OKButton_Click(object sender, EventArgs e)
        {
            // チャックされているものを確認
            var propList = new List<string>();
            int n = _PropertiesCheckedListBox.Items.Count;
            for (int i = 0; i < n; ++i)
            {
                if (_PropertiesCheckedListBox.GetItemChecked(i))
                {
                    var item = (CheckListItem)_PropertiesCheckedListBox.Items[i];
                    propList.Add(item.PropName);
                }
            }
            // JSONでエクスポート
            var editingData = new EditingData();
            editingData.Properties = propList.ToArray();
            editingData.TableType = _TableType;
            editingData.Data = _GameObjectList.ToArray();
            var editingDataList = new List<EditingData>();
            editingDataList.Add(editingData);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(editingDataList, options);
            // ファイル保存ダイアログの設定
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "";
            saveFileDialog.InitialDirectory = Properties.Settings.Default.ExportFileDirectory;
            if (saveFileDialog.InitialDirectory == "")
            {
                saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            }
            saveFileDialog.Filter = @"セーブ編集ファイル(*.json)|*.json";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = @"編集内容のエクスポート";
            saveFileDialog.RestoreDirectory = true;
            //ダイアログを表示する
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                using (StreamWriter fileStream = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    fileStream.Write(json);
                }
                Properties.Settings.Default.ExportFileDirectory = Path.GetDirectoryName(filePath);
                Properties.Settings.Default.Save();
                // 後始末
                saveFileDialog.Dispose();
                // 画面を閉じる
                DialogResult = DialogResult.OK;
                Close();
            }
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

        #region メソッド
        /// <summary>
        /// 世界用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForWorld()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"シナリオ", "ScenarioNumber"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"年", "Year"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"月", "Month"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"日", "Day"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"時間", "Time"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"総経過日数", "PlayDays"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"次の評定までの日数", "NextMeetingDays"), true);
        }

        /// <summary>
        /// 主人公用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForShujinko()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公", "ShujinkoID"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ1", "Face1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ2", "Face2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ3", "Face3"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ4", "Face4"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"妻愛情度", "WifeAffection"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"体力", "HitPoint"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"装備武器", "Weapon"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"装備防具", "Armor"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"所持金", "Money"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"預金", "Bank"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"薬草所持数", "Herbs"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"砂鉄所持数", "IronSands"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名所カードフラグ", "MeishoCardFlags"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"その他カードフラグ", "OtherCardFlags"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"医療経験値", "ExpMedical"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"無料診察回数", "NumOfFreeConsultations"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"薬の調合日数", "DaysOfCompounding"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"薬草採取日数", "DaysOfGettingHerbs"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"茶席回数", "NumOfTeaCeremonys"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"茶器制作経験値", "ExpTeaSetCraft"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"火薬調合経験値", "ExpGunpowderCraft"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉄製造経験値", "ExpIronCraft"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武具制作経験値", "ExpWeaponCraft"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉄砲制作経験値", "ExpGunCraft"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"瞑想経験値", "ExpMeditation"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"内政称号経験値", "ShogoExpDomesticAffairs"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"外交称号経験値", "ShogoExpDiplomacy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"合戦称号経験値", "ShogoNumOfWarWin"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"「人斬り」称号経験値", "ShogoNumOfKill"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"「奸臣」称号経験値", "ShogoNumOfRebellion"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"「今周公」称号経験値", "ShogoNumOfRecruiting"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"「鑑定士」称号経験値", "ShogoNumOfAppraisal"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"「芸術支援家」称号経験値", "ShogoNumOfArtAcceptance"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"「表裏比興」称号経験値", "ShogoNumOfBetrayal"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"「究極商人」称号経験値", "ShogoNumOfDevelopment"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"「究極用心棒」称号経験値", "ShogoNumOfWorkInBar"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"足軽技能経験値", "SkillExpInfantry"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"騎馬技能経験値", "SkillExpCavalry"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉄砲技能経験値", "SkillExpGun"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"水軍技能経験値", "SkillExpNavy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"弓術技能経験値", "SkillExpArchery"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武芸技能経験値", "SkillExpMartialArts"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"軍学技能経験値", "SkillExpTactics"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"忍術技能経験値", "SkillExpNinjutsu"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"建築技能経験値", "SkillExpBuilding"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"開墾技能経験値", "SkillExpAgriculture"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉱山技能経験値", "SkillExpMine"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"算術技能経験値", "SkillExpMath"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"礼法技能経験値", "SkillExpCourtesy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"弁舌技能経験値", "SkillExpSpeech"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"茶道技能経験値", "SkillExpTeaCeremony"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"医術技能経験値", "SkillExpMedical"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公流派の名前", "NameOfMyRyuha"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公流派の名前（読み）", "KanaOfMyRyuha"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公商家の屋号", "NameOfMyShoka"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公商家の屋号（読み）", "KanaOfMyShoka"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"個人戦勝利数", "NumOfWins"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"個人戦連勝数", "NumOfConsecutiveWins"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"個人戦敗北数", "NumOfDefeats"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"刀剣勝利数", "NumOfWinsWithSword"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"槍勝利数", "NumOfWinsWithSpear"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"苦無勝利数", "NumOfWinsWithKunai"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鎖鎌勝利数", "NumOfWinsWithKusarigama"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"火縄銃勝利数", "NumOfWinsWithGun"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"弓勝利数", "NumOfWinsWithBow"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"ライバル武将", "Rival"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"道場投資金", "DojoMoney"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"門弟数", "NumOfDisciples"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"兵法指南大名家", "InstructionDaimyoke"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"用心棒ランク", "BodyguardRank"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"用心棒雇用期間", "BodyguardDays"), true);
        }

        /// <summary>
        /// 武将用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForBusho()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"姓", "FamilyName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名", "GivenName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"姓（読み）", "KanaOfFamilyName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名（読み）", "KanaOfGivenName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ1", "Face1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ2", "Face2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"統率", "Leadership"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武力", "CombatPower"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"政務", "Politics"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"知謀", "Intellect"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"魅力", "Charm"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"足軽技能", "SkillInfantry"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"騎馬技能", "SkillCavalry"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉄砲技能", "SkillGun"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"水軍技能", "SkillNavy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"弓術技能", "SkillArchery"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武芸技能", "SkillMartialArts"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"軍学技能", "SkillTactics"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"忍術技能", "SkillNinjutsu"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"建築技能", "SkillBuilding"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"開墾技能", "SkillAgriculture"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉱山技能", "SkillMine"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"算術技能", "SkillMath"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"礼法技能", "SkillCourtesy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"弁舌技能", "SkillSpeech"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"茶道技能", "SkillTeaCeremony"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"医術技能", "SkillMedical"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"秘技カードフラグ", "HigiCardFlags"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"称号カードフラグ", "ShogoCardFlags"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"合戦カードフラグ", "KassenCardFlags"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"性別", "Sex"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"親密", "Closeness"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名声", "Fame"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"悪名", "Notorious"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"官位", "Kani"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"親密相性", "Compatibility"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"士官相性", "SeiryokuCompatibility"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"編制重視", "Formation"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"運", "Luck"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"死因", "CauseOfDeath"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"出自", "Origin"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武具", "WeaponType"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"気性", "Temper"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"精神", "Spirit"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主義", "Ism"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"行動", "Behavior"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"義理", "Honor"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"野心", "Ambition"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"好み", "Preference"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"物欲", "Desire"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"飲酒", "Drinking"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"士官", "Occupation"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"妻性格", "WifePersonality"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"所属勢力", "Seiryoku"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"所属拠点", "Kyoten"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"身分", "Mibun"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"立場", "Tachiba"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"上司", "Boss"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"忠誠", "Loyalty"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"俸禄", "Salary"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武士勲功", "BushiAchievement"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"商人勲功", "ShoninAchievement"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"忍者勲功", "NinjaAchievement"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"海賊勲功", "KaizokuAchievement"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"登場フラグ", "TojoFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"死亡フラグ", "DeadFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"神隠しフラグ1", "KamikakushiFlag1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"神隠しフラグ2", "KamikakushiFlag2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"面識フラグ", "MenshikiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"好みフラグ", "KonomiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"元服フラグ", "GenpukuFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"病フラグ", "YamaiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"恨みフラグ", "UramiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"不在フラグ", "HuzaiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"出陣フラグ", "ShutujinFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"外出禁止フラグ", "GaishutuKinshiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"父母", "Parents"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"祖父母", "Grandparents"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"妻", "Spouse"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武芸師匠", "Master"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"所属流派", "Ryuha"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"印可状", "License"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"生年", "YearOfBirth"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"登場年", "YearOfAdult"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"没年", "YearOfDeath"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"裏切り関係", "BetrayalFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"元配下関係", "PreviousRelationship"), true);
        }

        /// <summary>
        /// 汎用ライバル用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForGeneralPurpose()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"姓", "FamilyName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名", "GivenName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"姓（読み）", "KanaOfFamilyName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名（読み）", "KanaOfGivenName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ1", "Face1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ2", "Face2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"統率", "Leadership"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武力", "CombatPower"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"政務", "Politics"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"知謀", "Intellect"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"魅力", "Charm"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"足軽技能", "SkillInfantry"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"騎馬技能", "SkillCavalry"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉄砲技能", "SkillGun"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"水軍技能", "SkillNavy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"弓術技能", "SkillArchery"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武芸技能", "SkillMartialArts"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"軍学技能", "SkillTactics"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"忍術技能", "SkillNinjutsu"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"建築技能", "SkillBuilding"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"開墾技能", "SkillAgriculture"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉱山技能", "SkillMine"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"算術技能", "SkillMath"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"礼法技能", "SkillCourtesy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"弁舌技能", "SkillSpeech"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"茶道技能", "SkillTeaCeremony"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"医術技能", "SkillMedical"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"秘技カードフラグ", "HigiCardFlags"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"称号カードフラグ", "ShogoCardFlags"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"合戦カードフラグ", "KassenCardFlags"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"性別", "Sex"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"親密", "Closeness"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名声", "Fame"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"悪名", "Notorious"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"親密相性", "Compatibility"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"士官相性", "SeiryokuCompatibility"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"編制重視", "Formation"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"運", "Luck"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"死因", "CauseOfDeath"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"出自", "Origin"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武具", "WeaponType"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"気性", "Temper"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"精神", "Spirit"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主義", "Ism"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"行動", "Behavior"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"義理", "Honor"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"野心", "Ambition"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"好み", "Preference"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"物欲", "Desire"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"飲酒", "Drinking"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"士官", "Occupation"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"妻性格", "WifePersonality"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"所属勢力", "Seiryoku"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"所属拠点", "Kyoten"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"身分", "Mibun"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"立場", "Tachiba"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"上司", "Boss"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"忠誠", "Loyalty"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"俸禄", "Salary"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"商人勲功", "ShoninAchievement"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"忍者勲功", "NinjaAchievement"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"海賊勲功", "KaizokuAchievement"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"登場フラグ", "TojoFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"死亡フラグ", "DeadFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"神隠しフラグ1", "KamikakushiFlag1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"神隠しフラグ2", "KamikakushiFlag2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"面識フラグ", "MenshikiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"好みフラグ", "KonomiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"元服フラグ", "GenpukuFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"病フラグ", "YamaiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"恨みフラグ", "UramiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"不在フラグ", "HuzaiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"出陣フラグ", "ShutujinFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"外出禁止フラグ", "GaishutuKinshiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"父母", "Parents"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"祖父母", "Grandparents"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"印可状", "License"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"生年", "YearOfBirth"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"登場年", "YearOfAdult"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"裏切り関係", "BetrayalFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"元配下関係", "PreviousRelationship"), true);
        }

        /// <summary>
        /// イベント人物用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForEventPerson()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"姓", "FamilyName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名", "GivenName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"姓（読み）", "KanaOfFamilyName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名（読み）", "KanaOfGivenName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ1", "Face1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ2", "Face2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"足軽技能", "SkillInfantry"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"騎馬技能", "SkillCavalry"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉄砲技能", "SkillGun"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"水軍技能", "SkillNavy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"弓術技能", "SkillArchery"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"武芸技能", "SkillMartialArts"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"軍学技能", "SkillTactics"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"忍術技能", "SkillNinjutsu"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"建築技能", "SkillBuilding"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"開墾技能", "SkillAgriculture"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉱山技能", "SkillMine"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"算術技能", "SkillMath"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"礼法技能", "SkillCourtesy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"弁舌技能", "SkillSpeech"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"茶道技能", "SkillTeaCeremony"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"医術技能", "SkillMedical"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"性別", "Sex"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"親密", "Closeness"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"妻性格", "WifePersonality"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"所属拠点", "Kyoten"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"身分", "Mibun"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"登場フラグ", "TojoFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"死亡フラグ", "DeadFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"神隠しフラグ1", "KamikakushiFlag1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"神隠しフラグ2", "KamikakushiFlag2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"面識フラグ", "MenshikiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"好みフラグ", "KonomiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"元服フラグ", "GenpukuFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"病フラグ", "YamaiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"恨みフラグ", "UramiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"不在フラグ", "HuzaiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"外出禁止フラグ", "GaishutuKinshiFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"父母", "Parents"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"祖父母", "Grandparents"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"生年", "YearOfBirth"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"登場年", "YearOfAdult"), true);
        }

        /// <summary>
        /// 町人、その他用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForCitizen()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"姓", "FamilyName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名", "GivenName"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ1", "Face1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"顔グラ2", "Face2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"性別", "Sex"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"妻性格", "WifePersonality"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"身分", "Mibun"), true);
        }

        /// <summary>
        /// 大名家用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForDaimyoke()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"当主", "Leader"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"家紋", "FamilyCrest"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"朝廷貢献", "ImperialCourtContribution"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"不活性フラグ", "InactivationFlag"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"大方針", "Daihoshin"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"大方針ターゲット", "DaihoshinTarget"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"戦略", "Senryaku"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"戦略ターゲット", "SenryakuTarget"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"御用商人1", "GoyoShonin1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"御用商人2", "GoyoShonin2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"御用商人3", "GoyoShonin3"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"御用商人1の貢献度", "GoyoShoninContribution1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"御用商人2の貢献度", "GoyoShoninContribution2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"御用商人3の貢献度", "GoyoShoninContribution3"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公との関係", "RelationshipWithShujinko"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"出奔カウンタ", "DepartureCounter"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力との外交関係・感情", "Diplomacy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力との停戦約定", "Ceasefire"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力への攻込名分", "JustCause"), true);
        }

        /// <summary>
        /// 商家用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForShoka()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"商家名", "NameID"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"当主", "Leader"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"本店", "Home"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各店舗の店長", "Store.Leader"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各店舗の拠点", "Store.Kyoten"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各店舗の資金", "Store.Money"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各店舗の鉄砲在庫", "Store.Guns"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各店舗の宣伝効果", "Store.Advertisement"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"本店店舗ID", "HomeStore"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公との関係", "RelationshipWithShujinko"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"出奔カウンタ", "DepartureCounter"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力との外交関係・感情", "Diplomacy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力との停戦約定", "Ceasefire"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力への攻込名分", "JustCause"), true);
        }

        /// <summary>
        /// 忍者衆用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForNinjaShu()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"忍者衆名", "NameID"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"当主", "Leader"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"戦略", "Senryaku"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"戦略ターゲット", "SenryakuTarget"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公との関係", "RelationshipWithShujinko"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"出奔カウンタ", "DepartureCounter"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力との外交関係・感情", "Diplomacy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力との停戦約定", "Ceasefire"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力への攻込名分", "JustCause"), true);
        }

        /// <summary>
        /// 海賊衆用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForKaizokuShu()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"海賊衆名", "NameID"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"当主", "Leader"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"戦略", "Senryaku"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"戦略ターゲット", "SenryakuTarget"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"大型船技術", "ShipbuildingMiddle"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉄甲船技術", "ShipbuildingStrong"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公との関係", "RelationshipWithShujinko"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"出奔カウンタ", "DepartureCounter"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力との外交関係・感情", "Diplomacy"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力との停戦約定", "Ceasefire"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"各勢力への攻込名分", "JustCause"), true);
        }

        /// <summary>
        /// 城用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForShiro()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"城名", "NameID"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"城主", "Leader"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"規模", "Scale"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"立地", "Location"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"人口", "Population"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"石高", "Kokudaka"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"石高上限", "MaxKokudaka"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉱山", "Mine"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉱山上限", "MaxMine"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"軍資金", "Money"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"兵糧", "MilitaryFood"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"軍馬", "NumOfWarHorses"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉄砲", "NumOfGuns"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"大砲", "NumOfCannons"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"兵士数", "NumOfSoldiers"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"訓練度", "DegreeOfTraining"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"士気", "Morale"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"防御度", "DefensePower"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"住民安定度", "ResidentSupport"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"拠点画像", "Image"), true);
        }

        /// <summary>
        /// 町用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForMachi()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"町名", "NameID"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"規模", "Scale"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"立地", "Location"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"投資金", "Money"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"米相場", "RiceMarketPrice"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"米在庫", "RiceInventory"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"馬相場", "HorseMarketPrice"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"馬在庫", "HorseInventory"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"交易品", "TradeGoods"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"交易品の供給率", "TradeGoodsSupplyRate"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"米屋", "RiceStore"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"馬屋", "Stable"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"酒場", "Bar"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"宿屋", "Inn"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"民家", "PrivateHouse"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"寺", "Temple"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"道場1", "Dojo1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"道場2", "Dojo2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"医師宅", "DoctorHouse"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"茶人宅", "TeaMasterHouse"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鍛冶屋", "Blacksmith"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"職人宅", "CraftsmanHouse"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"南蛮寺", "ForeignTemple"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"南蛮商館", "ForeignFirm"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"公家宅", "AristocraticHouse"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"御所", "ImperialPalace"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"座", "Market"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"交易所", "TradingPost"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"拠点画像", "Image"), true);
        }

        /// <summary>
        /// 忍びの里用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForSato()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"里名", "NameID"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"拠点主", "Leader"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"規模", "Scale"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"立地", "Location"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"軍資金", "Money"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"兵糧", "MilitaryFood"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"兵士数", "NumOfSoldiers"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"訓練度", "DegreeOfTraining"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"士気", "Morale"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"防御度", "DefensePower"), true);
        }

        /// <summary>
        /// 海賊砦用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForToride()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"砦名", "NameID"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"拠点主", "Leader"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"規模", "Scale"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"立地", "Location"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"軍資金", "Money"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"兵糧", "MilitaryFood"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"関船数", "NumOfWeakWarships"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"大型船数", "NumOfMiddleWarships"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"鉄甲船数", "NumOfStrongWarships"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"訓練度", "DegreeOfTraining"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"士気", "Morale"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"防御度", "DefensePower"), true);
        }

        /// <summary>
        /// 通常アイテム用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForNormalItem()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"所有者", "Owner"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公の所持数", "Number"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"未鑑定フラグ", "SecretFlag"), true);
        }

        /// <summary>
        /// 製作アイテム用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForCraftItem()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"名前", "Name"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"読み", "Kana"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"画像", "Image"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"種類", "ItemType"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"価格", "Price"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"価値", "Rarity"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"上昇能力", "AbilityType"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"上昇量", "AbilityScores"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"所有者", "Owner"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"主人公の所持数", "Number"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"未鑑定フラグ", "SecretFlag"), true);
        }

        /// <summary>
        /// 販路用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForHanro()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"町1", "Machi1"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"町2", "Machi2"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"管理者", "Administrator"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"護衛", "Guard"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"勘定", "Kanjo"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"維持費", "MaintenanceCosts"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"販路種類", "Type"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"荷留め期間", "Stopping"), true);
        }

        /// <summary>
        /// 商圏用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForShoken()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"有力大名", "Daimyoke"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"商人司", "ShoninTukasa"), true);
        }

        /// <summary>
        /// 流派用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForRyuha()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"流派名", "NameID"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"宗家", "Leader"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"印可状", "License"), true);
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"道場破り", "DojoYaburi"), true);
        }

        /// <summary>
        /// 官位用のチェックリストボックス作成
        /// </summary>
        private void InitCheckedListForKani()
        {
            _PropertiesCheckedListBox.Items.Add(new CheckListItem(@"就任者", "InauguratedPerson"), true);
        }

        #endregion

        #region チェックリストアイテム
        /// <summary>
        /// チェックリストアイテム
        /// </summary>
        public class CheckListItem
        {
            /// <summary>
            /// 名前
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// プロパティ名
            /// </summary>
            public string PropName { get; set; }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="name">名前</param>
            /// <param name="propName">プロパティ名</param>
            public CheckListItem(string name, string propName)
            {
                Name = name;
                PropName = propName;
            }

            /// <summary>
            /// オブジェクトを文字列にして返す
            /// </summary>
            /// <returns>文字列</returns>
            public override string ToString()
            {
                return Name;
            }
        }

        #endregion

    }
}
