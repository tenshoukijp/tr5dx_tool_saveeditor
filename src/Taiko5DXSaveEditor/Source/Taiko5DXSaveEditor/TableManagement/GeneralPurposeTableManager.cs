using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor.TableManagement
{
    /// <summary>
    /// 汎用ライバルデータテーブルの管理クラス
    /// </summary>
    public class GeneralPurposeTableManager : GameDataTableManager
    {
        #region プロパティ
        /// <summary>
        /// テーブルの種類
        /// </summary>
        public override TableType TableType { get { return TableType.GeneralPurpose; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 汎用ライバルデータテーブルの管理クラスのコンストラクタ
        /// </summary>
        /// <param name="gameDataTable">管理対象のテーブル</param>
        /// <param name="gameData">表示対象のゲームデータ</param>
        public GeneralPurposeTableManager(DataGridView gameDataTable, GameData gameData)
            : base(gameDataTable, gameData)
        {
        }

        #endregion

        #region メソッド
        /// <summary>
        /// テーブルの初期化
        /// </summary>
        public override void InitializeTable()
        {
            // 表のリセット
            _GameDataTable.Columns.Clear();
            // 項目設定
            _GameDataTable.Columns.Add("ID", @"ID");
            _GameDataTable.Columns.Add("Name", @"名前");
            _GameDataTable.Columns.Add("State", @"登場");
            _GameDataTable.Columns.Add("Dead", @"生死");
            _GameDataTable.Columns.Add("Mibun", @"身分");
            _GameDataTable.Columns.Add("Kyoten", @"拠点");
            _GameDataTable.Columns.Add("Seiryoku", @"所属");
            _GameDataTable.Columns.Add("Tachiba", @"立場");
            _GameDataTable.Columns.Add("Boss", @"上司");
            _GameDataTable.Columns.Add("Leadership", @"統率");
            _GameDataTable.Columns.Add("CombatPower", @"武力");
            _GameDataTable.Columns.Add("Politics", @"政務");
            _GameDataTable.Columns.Add("Intellect", @"知謀");
            _GameDataTable.Columns.Add("Charm", @"魅力");
            _GameDataTable.Columns.Add("SkillInfantry", @"足軽");
            _GameDataTable.Columns.Add("SkillCavalry", @"騎馬");
            _GameDataTable.Columns.Add("SkillGun", @"鉄砲");
            _GameDataTable.Columns.Add("SkillNavy", @"水軍");
            _GameDataTable.Columns.Add("SkillArchery", @"弓術");
            _GameDataTable.Columns.Add("SkillMartialArts", @"武芸");
            _GameDataTable.Columns.Add("SkillTactics", @"軍学");
            _GameDataTable.Columns.Add("SkillNinjutsu", @"忍術");
            _GameDataTable.Columns.Add("SkillBuilding", @"建築");
            _GameDataTable.Columns.Add("SkillAgriculture", @"開墾");
            _GameDataTable.Columns.Add("SkillMine", @"鉱山");
            _GameDataTable.Columns.Add("SkillMath", @"算術");
            _GameDataTable.Columns.Add("SkillCourtesy", @"礼法");
            _GameDataTable.Columns.Add("SkillSpeech", @"弁舌");
            _GameDataTable.Columns.Add("SkillTeaCeremony", @"茶道");
            _GameDataTable.Columns.Add("SkillMedical", @"医術");
            _GameDataTable.Columns.Add("Closeness", @"親密");
            _GameDataTable.Columns.Add("Sex", @"性別");
            _GameDataTable.Columns.Add("YearOfBirth", @"誕生年");
            _GameDataTable.Columns.Add("YearOfAdult", @"登場年");
            _GameDataTable.Columns.Add("Parents", @"父母");
            _GameDataTable.Columns.Add("Grandparents", @"祖父母");
            _GameDataTable.Columns.Add("dummy", "");
            // 項目幅設定
            _GameDataTable.Columns["dummy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _GameDataTable.Columns["dummy"].SortMode = DataGridViewColumnSortMode.NotSortable;
            _GameDataTable.Columns["ID"].Width = 50;
            _GameDataTable.Columns["Name"].Width = 100;
            _GameDataTable.Columns["State"].Width = 80;
            _GameDataTable.Columns["Dead"].Width = 60;
            _GameDataTable.Columns["Mibun"].Width = 80;
            _GameDataTable.Columns["Kyoten"].Width = 100;
            _GameDataTable.Columns["Seiryoku"].Width = 100;
            _GameDataTable.Columns["Tachiba"].Width = 80;
            _GameDataTable.Columns["Boss"].Width = 100;
            _GameDataTable.Columns["Leadership"].Width = 60;
            _GameDataTable.Columns["CombatPower"].Width = 60;
            _GameDataTable.Columns["Politics"].Width = 60;
            _GameDataTable.Columns["Intellect"].Width = 60;
            _GameDataTable.Columns["Charm"].Width = 60;
            _GameDataTable.Columns["SkillInfantry"].Width = 60;
            _GameDataTable.Columns["SkillCavalry"].Width = 60;
            _GameDataTable.Columns["SkillGun"].Width = 60;
            _GameDataTable.Columns["SkillNavy"].Width = 60;
            _GameDataTable.Columns["SkillArchery"].Width = 60;
            _GameDataTable.Columns["SkillMartialArts"].Width = 60;
            _GameDataTable.Columns["SkillTactics"].Width = 60;
            _GameDataTable.Columns["SkillNinjutsu"].Width = 60;
            _GameDataTable.Columns["SkillBuilding"].Width = 60;
            _GameDataTable.Columns["SkillAgriculture"].Width = 60;
            _GameDataTable.Columns["SkillMine"].Width = 60;
            _GameDataTable.Columns["SkillMath"].Width = 60;
            _GameDataTable.Columns["SkillCourtesy"].Width = 60;
            _GameDataTable.Columns["SkillSpeech"].Width = 60;
            _GameDataTable.Columns["SkillTeaCeremony"].Width = 60;
            _GameDataTable.Columns["SkillMedical"].Width = 60;
            _GameDataTable.Columns["Closeness"].Width = 60;
            _GameDataTable.Columns["Sex"].Width = 60;
            _GameDataTable.Columns["YearOfBirth"].Width = 60;
            _GameDataTable.Columns["YearOfAdult"].Width = 60;
            _GameDataTable.Columns["Parents"].Width = 100;
            _GameDataTable.Columns["Grandparents"].Width = 100;
            // 固定列
            _GameDataTable.Columns["ID"].Frozen = true;
            _GameDataTable.Columns["Name"].Frozen = true;
            // データ追加
            int n = GameData.NumOfGeneralPurpose;
            _GameDataTable.Rows.Add(n);
            for (int i = 0; i < n; ++i)
            {
                int index = GameData.NumOfBusho + i;
                Busho busho = _GameData.BushoList[index];
                int id = busho.ID;
                _GameDataTable.Rows[i].Cells["ID"].Value = id;
            }
            UpdateTable(_GameDataTable.Rows.Cast<DataGridViewRow>());
            // 選択を外す
            _GameDataTable.CurrentCell = null;

            // コンテキストメニューの設定
            _ContextMenu.Items.Clear();
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"主要項目の編集", null, (sender, e) =>
            {
                OpenBasicEditForm();
            }));
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"隠し項目の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.BushoEdit.HiddenEditForm(ids, _GameData);
                OpenEditForm(editFormCreater);
            }));
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"所属・状態の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.BushoEdit.AffiliationEditForm(ids, _GameData);
                OpenEditForm(editFormCreater);
            }));
            _ContextMenu.Items.Add(new ToolStripMenuItem(@"人間関係・生没年の編集", null, (sender, e) =>
            {
                Func<int[], DataEditForms.DataEditForm> editFormCreater =
                    (ids) => new DataEditForms.BushoEdit.RelationshipEditForm(ids, _GameData);
                OpenEditForm(editFormCreater);
            }));
        }

        /// <summary>
        /// テーブルのアップデート
        /// </summary>
        /// <param name="selectedRows">選択されている行</param>
        public override void UpdateTable(IEnumerable<DataGridViewRow> selectedRows)
        {
            foreach (DataGridViewRow row in selectedRows)
            {
                int id = (int)row.Cells["ID"].Value;
                Busho busho = _GameData.BushoList[id];
                // 値の取得
                string name = busho.Name;
                var mibun = new GameDataTableCellValue("", busho.Mibun);
                if (busho.Mibun != GameData.NoneMibunID)
                    mibun.Text = _GameData.NameListDictionary["Mibun"][busho.Mibun];
                else
                    mibun.Text = @"死亡";
                var sex = new GameDataTableCellValue(busho.Sex == 0 ? @"男" : @"女", busho.Sex);
                var state = GameDataTableCellValue.Empty;
                var dead = GameDataTableCellValue.Empty;
                var kyoten = GameDataTableCellValue.Empty;
                var skillInfantry = GameDataTableCellValue.Empty;
                var skillCavalry = GameDataTableCellValue.Empty;
                var skillGun = GameDataTableCellValue.Empty;
                var skillNavy = GameDataTableCellValue.Empty;
                var skillArchery = GameDataTableCellValue.Empty;
                var skillMartialArts = GameDataTableCellValue.Empty;
                var skillTactics = GameDataTableCellValue.Empty;
                var skillNinjutsu = GameDataTableCellValue.Empty;
                var skillBuilding = GameDataTableCellValue.Empty;
                var skillAgriculture = GameDataTableCellValue.Empty;
                var skillMine = GameDataTableCellValue.Empty;
                var skillMath = GameDataTableCellValue.Empty;
                var skillCourtesy = GameDataTableCellValue.Empty;
                var skillSpeech = GameDataTableCellValue.Empty;
                var skillTeaCeremony = GameDataTableCellValue.Empty;
                var skillMedical = GameDataTableCellValue.Empty;
                var closeness = GameDataTableCellValue.Empty;
                var yearOfBirth = GameDataTableCellValue.Empty;
                var yearOfAdult = GameDataTableCellValue.Empty;
                var parents = GameDataTableCellValue.Empty;
                var grandparents = GameDataTableCellValue.Empty;
                if ((busho.PeopleCategory == PeopleCategory.Busho) || (busho.PeopleCategory == PeopleCategory.GeneralPurpose) || (busho.PeopleCategory == PeopleCategory.EventPerson))
                {
                    if (busho.TojoFlag)
                    {
                        state.Text = @"登場";
                        state.SortValue = 1;
                    }
                    else
                    {
                        state.Text = @"未登場";
                        state.SortValue = 0;
                    }
                    if (busho.DeadFlag)
                    {
                        dead.Text = @"死亡";
                        dead.SortValue = 1;
                    }
                    else
                    {
                        dead.Text = @"生存";
                        dead.SortValue = 0;
                    }
                    if (busho.Kyoten != GameData.NoneKyotenIDForDead)
                    {
                        kyoten.Text = _GameData.KyotenList[busho.Kyoten].Name;
                    }
                    else
                    {
                        kyoten.Text = @"無所属";
                    }
                    kyoten.SortValue = busho.Kyoten;
                    string[] skillTexts = new string[] { @"〇〇〇〇", @"〇〇〇●", @"〇〇●●", @"〇●●●", @"●●●●", @"★★★★" };
                    skillInfantry.Text = skillTexts[busho.SkillInfantry];
                    skillInfantry.SortValue = busho.SkillInfantry;
                    skillCavalry.Text = skillTexts[busho.SkillCavalry];
                    skillCavalry.SortValue = busho.SkillCavalry;
                    skillGun.Text = skillTexts[busho.SkillGun];
                    skillGun.SortValue = busho.SkillGun;
                    skillNavy.Text = skillTexts[busho.SkillNavy];
                    skillNavy.SortValue = busho.SkillNavy;
                    skillArchery.Text = skillTexts[busho.SkillArchery];
                    skillArchery.SortValue = busho.SkillArchery;
                    skillMartialArts.Text = skillTexts[busho.SkillMartialArts];
                    skillMartialArts.SortValue = busho.SkillMartialArts;
                    skillTactics.Text = skillTexts[busho.SkillTactics];
                    skillTactics.SortValue = busho.SkillTactics;
                    skillNinjutsu.Text = skillTexts[busho.SkillNinjutsu];
                    skillNinjutsu.SortValue = busho.SkillNinjutsu;
                    skillBuilding.Text = skillTexts[busho.SkillBuilding];
                    skillBuilding.SortValue = busho.SkillBuilding;
                    skillAgriculture.Text = skillTexts[busho.SkillAgriculture];
                    skillAgriculture.SortValue = busho.SkillAgriculture;
                    skillMine.Text = skillTexts[busho.SkillMine];
                    skillMine.SortValue = busho.SkillMine;
                    skillMath.Text = skillTexts[busho.SkillMath];
                    skillMath.SortValue = busho.SkillMath;
                    skillCourtesy.Text = skillTexts[busho.SkillCourtesy];
                    skillCourtesy.SortValue = busho.SkillCourtesy;
                    skillSpeech.Text = skillTexts[busho.SkillSpeech];
                    skillSpeech.SortValue = busho.SkillSpeech;
                    skillTeaCeremony.Text = skillTexts[busho.SkillTeaCeremony];
                    skillTeaCeremony.SortValue = busho.SkillTeaCeremony;
                    skillMedical.Text = skillTexts[busho.SkillMedical];
                    skillMedical.SortValue = busho.SkillMedical;
                    closeness.Text = busho.Closeness.ToString();
                    closeness.SortValue = busho.Closeness;
                    yearOfBirth.Text = (busho.YearOfBirth + 1460).ToString();
                    yearOfBirth.SortValue = (busho.YearOfBirth + 1460);
                    yearOfAdult.Text = (busho.YearOfAdult + 1500).ToString();
                    yearOfAdult.SortValue = (busho.YearOfAdult + 1500);
                    if (busho.Parents != GameData.NoneBushoID)
                    {
                        if (busho.Parents < GameData.NoneBushoID - 1)
                            parents.Text = _GameData.BushoList[busho.Parents].Name;
                        else
                            parents.Text = _GameData.NameListDictionary["Parents"][busho.Parents - (GameData.NoneBushoID - 1)];
                        parents.SortValue = busho.Parents;
                    }
                    if (busho.Grandparents != GameData.NoneBushoID)
                    {
                        if (busho.Grandparents < GameData.NoneBushoID - 1)
                            grandparents.Text = _GameData.BushoList[busho.Grandparents].Name;
                        else
                            grandparents.Text = _GameData.NameListDictionary["Parents"][busho.Grandparents - (GameData.NoneBushoID - 1)];
                        grandparents.SortValue = busho.Grandparents;
                    }
                }
                var seiryoku = GameDataTableCellValue.Empty;
                var tachiba = GameDataTableCellValue.Empty;
                var boss = GameDataTableCellValue.Empty;
                var leadership = GameDataTableCellValue.Empty;
                var combatPower = GameDataTableCellValue.Empty;
                var politics = GameDataTableCellValue.Empty;
                var intellect = GameDataTableCellValue.Empty;
                var charm = GameDataTableCellValue.Empty;
                if ((busho.PeopleCategory == PeopleCategory.Busho) || (busho.PeopleCategory == PeopleCategory.GeneralPurpose))
                {
                    if (busho.Seiryoku != GameData.NoneSeiryokuID)
                    {
                        seiryoku.Text = _GameData.SeiryokuList[busho.Seiryoku].Name;
                    }
                    else
                    {
                        seiryoku.Text = @"無所属";
                    }
                    seiryoku.SortValue = busho.Seiryoku;
                    tachiba.Text = _GameData.NameListDictionary["Tachiba"][busho.Tachiba];
                    tachiba.SortValue = busho.Tachiba;
                    if (busho.Boss != GameData.NoneBushoID)
                    {
                        boss.Text = _GameData.BushoList[busho.Boss].Name;
                        boss.SortValue = busho.Boss;
                    }
                    leadership.Text = busho.Leadership.ToString();
                    leadership.SortValue = busho.Leadership;
                    combatPower.Text = busho.CombatPower.ToString();
                    combatPower.SortValue = busho.CombatPower;
                    politics.Text = busho.Politics.ToString();
                    politics.SortValue = busho.Politics;
                    intellect.Text = busho.Intellect.ToString();
                    intellect.SortValue = busho.Intellect;
                    charm.Text = busho.Charm.ToString();
                    charm.SortValue = busho.Charm;
                }
                // 代入
                row.Cells["Name"].Value = name;
                row.Cells["State"].Value = state;
                row.Cells["Dead"].Value = dead;
                row.Cells["Mibun"].Value = mibun;
                row.Cells["Kyoten"].Value = kyoten;
                row.Cells["Seiryoku"].Value = seiryoku;
                row.Cells["Tachiba"].Value = tachiba;
                row.Cells["Boss"].Value = boss;
                row.Cells["Leadership"].Value = leadership;
                row.Cells["CombatPower"].Value = combatPower;
                row.Cells["Politics"].Value = politics;
                row.Cells["Intellect"].Value = intellect;
                row.Cells["Charm"].Value = charm;
                row.Cells["SkillInfantry"].Value = skillInfantry;
                row.Cells["SkillCavalry"].Value = skillCavalry;
                row.Cells["SkillGun"].Value = skillGun;
                row.Cells["SkillNavy"].Value = skillNavy;
                row.Cells["SkillArchery"].Value = skillArchery;
                row.Cells["SkillMartialArts"].Value = skillMartialArts;
                row.Cells["SkillTactics"].Value = skillTactics;
                row.Cells["SkillNinjutsu"].Value = skillNinjutsu;
                row.Cells["SkillBuilding"].Value = skillBuilding;
                row.Cells["SkillAgriculture"].Value = skillAgriculture;
                row.Cells["SkillMine"].Value = skillMine;
                row.Cells["SkillMath"].Value = skillMath;
                row.Cells["SkillCourtesy"].Value = skillCourtesy;
                row.Cells["SkillSpeech"].Value = skillSpeech;
                row.Cells["SkillTeaCeremony"].Value = skillTeaCeremony;
                row.Cells["SkillMedical"].Value = skillMedical;
                row.Cells["Closeness"].Value = closeness;
                row.Cells["Sex"].Value = sex;
                row.Cells["YearOfBirth"].Value = yearOfBirth;
                row.Cells["YearOfAdult"].Value = yearOfAdult;
                row.Cells["Parents"].Value = parents;
                row.Cells["Grandparents"].Value = grandparents;
            }
        }

        /// <summary>
        /// 基本事項を編集するためのフォームを開く
        /// </summary>
        public override void OpenBasicEditForm()
        {
            Func<int[], DataEditForms.DataEditForm> editFormCreater =
                (ids) => new DataEditForms.BushoEdit.BasicEditForm(ids, _GameData);
            OpenEditForm(editFormCreater);
        }

        #endregion
    }
}
