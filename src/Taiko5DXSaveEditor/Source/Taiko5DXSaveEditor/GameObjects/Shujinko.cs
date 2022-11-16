using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 主人公
    /// </summary>
    [Serializable]
    public class Shujinko : GameObject
    {
        #region プロパティ：主人公選択
        /// <summary>
        /// 主人公ID。
        /// 変更するとゲーム上で操作するキャラを変更できる。
        /// </summary>
        public ushort ShujinkoID { get; set; } = 0;

        /// <summary>
        /// 顔グラ1つ目のID
        /// </summary>
        public ushort Face1 { get; set; } = 0;

        /// <summary>
        /// 顔グラ2つ目のID
        /// </summary>
        public ushort Face2 { get; set; } = 0;

        /// <summary>
        /// 顔グラ3つ目のID
        /// </summary>
        public ushort Face3 { get; set; } = 0;

        /// <summary>
        /// 顔グラ4つ目のID
        /// </summary>
        public ushort Face4 { get; set; } = 0;

        #endregion

        #region プロパティ：基本ステータス
        /// <summary>
        /// 妻愛情度
        /// </summary>
        public byte WifeAffection { get; set; } = 0;

        /// <summary>
        /// 体力。最大値は100
        /// </summary>
        public byte HitPoint { get; set; } = 0;

        /// <summary>
        /// 装備武器のアイテムID
        /// </summary>
        public ushort Weapon { get; set; } = 0;

        /// <summary>
        /// 装備防具のアイテムID
        /// </summary>
        public ushort Armor { get; set; } = 0;

        /// <summary>
        /// 所持金。
        /// 1桁目は100文。
        /// </summary>
        public uint Money { get; set; } = 0;

        /// <summary>
        /// 自宅に預けてるお金
        /// </summary>
        public uint Bank { get; set; } = 0;

        /// <summary>
        /// 薬草所持数
        /// </summary>
        public ushort Herbs { get; set; } = 0;

        /// <summary>
        /// 砂鉄所持数
        /// </summary>
        public ushort IronSands { get; set; } = 0;

        #endregion

        #region プロパティ：職業経験
        /// <summary>
        /// 医療経験値
        /// </summary>
        public uint ExpMedical { get; set; } = 0;

        /// <summary>
        /// 無料診察回数
        /// </summary>
        public uint NumOfFreeConsultations { get; set; } = 0;

        /// <summary>
        /// 薬の調合日数
        /// </summary>
        public uint DaysOfCompounding { get; set; } = 0;

        /// <summary>
        /// 薬草採取日数
        /// </summary>
        public uint DaysOfGettingHerbs { get; set; } = 0;

        /// <summary>
        /// 茶席回数
        /// </summary>
        public uint NumOfTeaCeremonys { get; set; } = 0;

        /// <summary>
        /// 茶器制作経験値
        /// </summary>
        public uint ExpTeaSetCraft { get; set; } = 0;

        /// <summary>
        /// 火薬調合経験値
        /// </summary>
        public ushort ExpGunpowderCraft { get; set; } = 0;

        /// <summary>
        /// 鉄製造経験値
        /// </summary>
        public ushort ExpIronCraft { get; set; } = 0;

        /// <summary>
        /// 武具制作経験値
        /// </summary>
        public ushort ExpWeaponCraft { get; set; } = 0;

        /// <summary>
        /// 鉄砲制作経験値
        /// </summary>
        public ushort ExpGunCraft { get; set; } = 0;

        /// <summary>
        /// 瞑想経験値
        /// </summary>
        public ushort ExpMeditation { get; set; } = 0;

        #endregion

        #region 個人戦勝敗
        /// <summary>
        /// 勝利数
        /// </summary>
        public uint NumOfWins { get; set; } = 0;

        /// <summary>
        /// 連勝数
        /// </summary>
        public uint NumOfConsecutiveWins { get; set; } = 0;

        /// <summary>
        /// 敗北数
        /// </summary>
        public uint NumOfDefeats { get; set; } = 0;

        /// <summary>
        /// 刀剣勝利数
        /// </summary>
        public byte NumOfWinsWithSword { get; set; } = 0;

        /// <summary>
        /// 槍勝利数
        /// </summary>
        public byte NumOfWinsWithSpear { get; set; } = 0;

        /// <summary>
        /// 苦無勝利数
        /// </summary>
        public byte NumOfWinsWithKunai { get; set; } = 0;

        /// <summary>
        /// 鎖鎌勝利数
        /// </summary>
        public byte NumOfWinsWithKusarigama { get; set; } = 0;

        /// <summary>
        /// 火縄銃勝利数
        /// </summary>
        public byte NumOfWinsWithGun { get; set; } = 0;

        /// <summary>
        /// 弓勝利数
        /// </summary>
        public byte NumOfWinsWithBow { get; set; } = 0;

        #endregion

        #region プロパティ：所持カード
        /// <summary>
        /// 名所カードフラグ
        /// </summary>
        public ulong MeishoCardFlags { get; set; } = 0;

        /// <summary>
        /// その他カードフラグ
        /// </summary>
        public ulong OtherCardFlags { get; set; } = 0;

        #endregion

        #region プロパティ：スキル・称号経験
        /// <summary>
        /// 足軽の技能経験値
        /// </summary>
        public byte SkillExpInfantry { get; set; } = 0;

        /// <summary>
        /// 騎馬の技能経験値
        /// </summary>
        public byte SkillExpCavalry { get; set; } = 0;

        /// <summary>
        /// 鉄砲の技能経験値
        /// </summary>
        public byte SkillExpGun { get; set; } = 0;

        /// <summary>
        /// 水軍の技能経験値
        /// </summary>
        public byte SkillExpNavy { get; set; } = 0;

        /// <summary>
        /// 弓術の技能経験値
        /// </summary>
        public byte SkillExpArchery { get; set; } = 0;

        /// <summary>
        /// 武芸の技能経験値
        /// </summary>
        public byte SkillExpMartialArts { get; set; } = 0;

        /// <summary>
        /// 軍学の技能経験値
        /// </summary>
        public byte SkillExpTactics { get; set; } = 0;

        /// <summary>
        /// 忍術の技能経験値
        /// </summary>
        public byte SkillExpNinjutsu { get; set; } = 0;

        /// <summary>
        /// 建築の技能経験値
        /// </summary>
        public byte SkillExpBuilding { get; set; } = 0;

        /// <summary>
        /// 開墾の技能経験値
        /// </summary>
        public byte SkillExpAgriculture { get; set; } = 0;

        /// <summary>
        /// 鉱山の技能経験値
        /// </summary>
        public byte SkillExpMine { get; set; } = 0;

        /// <summary>
        /// 算術の技能経験値
        /// </summary>
        public byte SkillExpMath { get; set; } = 0;

        /// <summary>
        /// 礼法の技能経験値
        /// </summary>
        public byte SkillExpCourtesy { get; set; } = 0;

        /// <summary>
        /// 弁舌の技能経験値
        /// </summary>
        public byte SkillExpSpeech { get; set; } = 0;

        /// <summary>
        /// 茶道の技能経験値
        /// </summary>
        public byte SkillExpTeaCeremony { get; set; } = 0;

        /// <summary>
        /// 医術の技能経験値
        /// </summary>
        public byte SkillExpMedical { get; set; } = 0;

        /// <summary>
        /// 内政の称号経験値
        /// </summary>
        public uint ShogoExpDomesticAffairs { get; set; } = 0;

        /// <summary>
        /// 外交の称号経験値
        /// </summary>
        public uint ShogoExpDiplomacy { get; set; } = 0;

        /// <summary>
        /// 合戦勝利回数
        /// </summary>
        public uint ShogoNumOfWarWin { get; set; } = 0;

        /// <summary>
        /// 人斬りの称号経験値。
        /// 辻斬りで人を殺した数。3人で達成。
        /// </summary>
        public byte ShogoNumOfKill { get; set; } = 0;

        /// <summary>
        /// 奸臣の称号経験値。
        /// 謀反回数。2回で達成。
        /// </summary>
        public byte ShogoNumOfRebellion { get; set; } = 0;

        /// <summary>
        /// 今周公の称号経験値。
        /// 勧誘・引き抜き回数。20人で達成。
        /// </summary>
        public byte ShogoNumOfRecruiting { get; set; } = 0;

        /// <summary>
        /// 鑑定士の称号経験値。
        /// 目利き回数。10回で達成。
        /// </summary>
        public byte ShogoNumOfAppraisal { get; set; } = 0;

        /// <summary>
        /// 芸術支援家の称号経験値。
        /// 職人に依頼した芸術品を受け取った回数。10回で達成。
        /// </summary>
        public byte ShogoNumOfArtAcceptance { get; set; } = 0;

        /// <summary>
        /// 表裏比興の称号経験値。
        /// 裏切り回数。5回で達成。
        /// </summary>
        public byte ShogoNumOfBetrayal { get; set; } = 0;

        /// <summary>
        /// 究極商人の称号経験値。
        /// 二次加工品の開発回数。10回で達成。
        /// </summary>
        public byte ShogoNumOfDevelopment { get; set; } = 0;

        /// <summary>
        /// 究極用心棒の称号経験値。
        /// 酒場の仕事達成数。30回で達成。
        /// </summary>
        public byte ShogoNumOfWorkInBar { get; set; } = 0;

        #endregion

        #region プロパティ：自作流派・屋号の設定
        /// <summary>
        /// 自作流派の名前。
        /// 4文字+流。
        /// </summary>
        public string NameOfMyRyuha { get; set; } = "";

        /// <summary>
        /// 自作流派の読み。
        /// 半角カタカナ13文字。
        /// </summary>
        public string KanaOfMyRyuha { get; set; } = "";

        /// <summary>
        /// 屋号。
        /// 3文字+屋。
        /// </summary>
        public string NameOfMyShoka { get; set; } = "";

        /// <summary>
        /// 屋号の読み。
        /// 半角カタカナ11文字。
        /// </summary>
        public string KanaOfMyShoka { get; set; } = "";

        #endregion

        #region プロパティ：その他
        /// <summary>
        /// ライバル武将ID
        /// </summary>
        public ushort Rival { get; set; } = 0;

        /// <summary>
        /// 道場投資金
        /// </summary>
        public ushort DojoMoney { get; set; } = 0;

        /// <summary>
        /// 門弟数
        /// </summary>
        public ushort NumOfDisciples { get; set; } = 0;

        /// <summary>
        /// 兵法指南大名家
        /// </summary>
        public byte InstructionDaimyoke { get; set; } = 0;

        /// <summary>
        /// 兵法指南カウンタ
        /// </summary>
        public byte InstructionCounter { get; set; } = 0;

        /// <summary>
        /// 用心棒ランク。
        /// 0-7まである。
        /// </summary>
        public byte BodyguardRank { get; set; } = 0;

        /// <summary>
        /// 用心棒雇用期間 (255で無し)
        /// </summary>
        public byte BodyguardDays { get; set; } = 0;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 主人公のコンストラクタ
        /// </summary>
        public Shujinko()
        {
        }

        #endregion
    }
}
