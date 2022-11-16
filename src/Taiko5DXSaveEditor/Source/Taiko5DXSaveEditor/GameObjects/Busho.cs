using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taiko5DXSaveEditor.GameObjects
{
    /// <summary>
    /// 武将
    /// </summary>
    [Serializable]
    public class Busho : GameObject
    {
        #region ツールで管理するプロパティ
        /// <summary>
        /// 人物カテゴリ
        /// </summary>
        public PeopleCategory PeopleCategory { get; set; } = PeopleCategory.Busho;

        /// <summary>
        /// 姓名を合わせて返す
        /// </summary>
        public string Name { get { return FamilyName + GivenName; } }

        #endregion

        #region プロパティ：姓名・顔グラ
        /// <summary>
        /// 姓。
        /// Shift JISの4文字。
        /// </summary>
        public string FamilyName { get; set; } = "";

        /// <summary>
        /// 名。
        /// Shift JISの4文字。
        /// </summary>
        public string GivenName { get; set; } = "";

        /// <summary>
        /// 姓の読み。
        /// Shift JISの半角カナ9文字。
        /// (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public string KanaOfFamilyName { get; set; } = "";

        /// <summary>
        /// 名の読み。
        /// Shift JISの半角カナ9文字。
        /// (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public string KanaOfGivenName { get; set; } = "";

        /// <summary>
        /// 顔グラ1つ目のID
        /// </summary>
        public ushort Face1 { get; set; } = 0;

        /// <summary>
        /// 顔グラ2つ目のID
        /// </summary>
        public ushort Face2 { get; set; } = 0;

        #endregion

        #region プロパティ：基本ステータス
        /// <summary>
        /// 統率 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Leadership { get; set; } = 0;

        /// <summary>
        /// 武力 (武将と汎用ライバルのみ)
        /// </summary>
        public byte CombatPower { get; set; } = 0;

        /// <summary>
        /// 政務 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Politics { get; set; } = 0;

        /// <summary>
        /// 知謀 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Intellect { get; set; } = 0;

        /// <summary>
        /// 魅力 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Charm { get; set; } = 0;

        #endregion

        #region プロパティ：スキル
        /// <summary>
        /// 足軽の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillInfantry { get; set; } = 0;

        /// <summary>
        /// 騎馬の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillCavalry { get; set; } = 0;

        /// <summary>
        /// 鉄砲の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillGun { get; set; } = 0;

        /// <summary>
        /// 水軍の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillNavy { get; set; } = 0;

        /// <summary>
        /// 弓術の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillArchery { get; set; } = 0;

        /// <summary>
        /// 武芸の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillMartialArts { get; set; } = 0;

        /// <summary>
        /// 軍学の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillTactics { get; set; } = 0;

        /// <summary>
        /// 忍術の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillNinjutsu { get; set; } = 0;

        /// <summary>
        /// 建築の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillBuilding { get; set; } = 0;

        /// <summary>
        /// 開墾の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillAgriculture { get; set; } = 0;

        /// <summary>
        /// 鉱山の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillMine { get; set; } = 0;

        /// <summary>
        /// 算術の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillMath { get; set; } = 0;

        /// <summary>
        /// 礼法の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillCourtesy { get; set; } = 0;

        /// <summary>
        /// 弁舌の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillSpeech { get; set; } = 0;

        /// <summary>
        /// 茶道の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillTeaCeremony { get; set; } = 0;

        /// <summary>
        /// 医術の技能 (0-5) (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte SkillMedical { get; set; } = 0;

        #endregion

        #region プロパティ：カード
        /// <summary>
        /// 秘技カードフラグ (武将と汎用ライバルのみ)
        /// </summary>
        public byte[] HigiCardFlags { get; set; } = null;

        /// <summary>
        /// 称号カードフラグ (武将と汎用ライバルのみ)
        /// </summary>
        public byte[] ShogoCardFlags { get; set; } = null;

        /// <summary>
        /// 合戦カードフラグ (武将と汎用ライバルのみ)
        /// </summary>
        public byte[] KassenCardFlags { get; set; } = null;

        #endregion

        #region プロパティ：性別・性格・年齢など
        /// <summary>
        /// 性別
        /// </summary>
        public byte Sex { get; set; } = 0;

        /// <summary>
        /// 誕生年。
        /// 1460年から何年後に生まれたか。
        /// (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte YearOfBirth { get; set; } = 0;

        /// <summary>
        /// 元服年。
        /// 1500年から何年後か。通常15歳で元服。
        /// (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte YearOfAdult { get; set; } = 0;

        /// <summary>
        /// 没年。(武将のみ設定可)
        /// 1500年から何年後か。
        /// </summary>
        public byte YearOfDeath { get; set; } = 0;

        /// <summary>
        /// 死因 (武将と汎用ライバルのみ)
        /// </summary>
        public byte CauseOfDeath { get; set; } = 0;

        /// <summary>
        /// 出自 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Origin { get; set; } = 0;

        /// <summary>
        /// 武具 (武将と汎用ライバルのみ)
        /// </summary>
        public byte WeaponType { get; set; } = 0;

        /// <summary>
        /// 名声 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Fame { get; set; } = 0;

        /// <summary>
        /// 悪名 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Notorious { get; set; } = 0;

        /// <summary>
        /// 気性 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Temper { get; set; } = 0;

        /// <summary>
        /// 精神 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Spirit { get; set; } = 0;

        /// <summary>
        /// 主義 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Ism { get; set; } = 0;

        /// <summary>
        /// 行動 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Behavior { get; set; } = 0;

        /// <summary>
        /// 義理 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Honor { get; set; } = 0;

        /// <summary>
        /// 野心 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Ambition { get; set; } = 0;

        /// <summary>
        /// 好み (武将と汎用ライバルのみ)
        /// </summary>
        public byte Preference { get; set; } = 0;

        /// <summary>
        /// 物欲 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Desire { get; set; } = 0;

        /// <summary>
        /// 飲酒 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Drinking { get; set; } = 0;

        /// <summary>
        /// 士官傾向 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Occupation { get; set; } = 0;

        /// <summary>
        /// 妻性格
        /// </summary>
        public byte WifePersonality { get; set; } = 0;

        /// <summary>
        /// 親密相性。0-99でループ。
        /// 差が小さいほど親密を上げやすい。
        /// (武将と汎用ライバルのみ)
        /// </summary>
        public byte Compatibility { get; set; } = 0;

        /// <summary>
        /// 士官相性。0-99でループ。
        /// 上司との差小さいほど引き抜かれにくい。
        /// (武将と汎用ライバルのみ)
        /// </summary>
        public byte SeiryokuCompatibility { get; set; } = 0;

        /// <summary>
        /// 編制重視。軍団編成するときに何を重視するか。
        /// (武将と汎用ライバルのみ)
        /// </summary>
        public byte Formation { get; set; } = 0;

        /// <summary>
        /// 運 (0-3) (武将と汎用ライバルのみ)
        /// </summary>
        public byte Luck { get; set; } = 0;

        #endregion

        #region プロパティ：所属・拠点・状態
        /// <summary>
        /// 身分
        /// </summary>
        public byte Mibun { get; set; } = 0;

        /// <summary>
        /// 立場 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Tachiba { get; set; } = 0;

        /// <summary>
        /// 所属勢力 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Seiryoku { get; set; } = 0;

        /// <summary>
        /// 所属拠点 (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public ushort Kyoten { get; set; } = 0;

        /// <summary>
        /// 上司武将のID (武将と汎用ライバルのみ)
        /// </summary>
        public ushort Boss { get; set; } = 0;

        /// <summary>
        /// 俸禄 (武将と汎用ライバルのみ)
        /// </summary>
        public ushort Salary { get; set; } = 0;

        /// <summary>
        /// 忠誠 (武将と汎用ライバルのみ)
        /// </summary>
        public byte Loyalty { get; set; } = 0;

        /// <summary>
        /// 官位 (武将のみ設定可)
        /// </summary>
        public byte Kani { get; set; } = 0;

        /// <summary>
        /// 武士勲功 (武将のみ設定可)
        /// </summary>
        public ushort BushiAchievement { get; set; } = 0;

        /// <summary>
        /// 商人勲功 (武将と汎用ライバルのみ)
        /// </summary>
        public ushort ShoninAchievement { get; set; } = 0;

        /// <summary>
        /// 忍者勲功 (武将と汎用ライバルのみ)
        /// </summary>
        public ushort NinjaAchievement { get; set; } = 0;

        /// <summary>
        /// 海賊勲功 (武将と汎用ライバルのみ)
        /// </summary>
        public ushort KaizokuAchievement { get; set; } = 0;

        /// <summary>
        /// 状態1。
        /// 80h登場、40h面識、20h贈物、10h好み、04h不在、02h死亡、01h病気。
        /// (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte State1 { get; set; } = 0;

        /// <summary>
        /// 状態2。
        /// 40h恨み、20h茶席、02h??、01h死亡。
        /// (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte State2 { get; set; } = 0;

        /// <summary>
        /// 状態3。
        /// 08h薬投与、04h??、02h神隠し、01h外出禁止。
        /// (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte State3 { get; set; } = 0;

        /// <summary>
        /// 状態4。
        /// 01h出陣フラグ、02h-04hビット目:主命フラグ、10h死刑フラグ、20h放免フラグ、80h下野フラグ
        /// (武将と汎用ライバルのみ)
        /// </summary>
        public byte State4 { get; set; } = 0;

        #endregion

        #region プロパティ：人間関係
        /// <summary>
        /// 親密度 (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public byte Closeness { get; set; } = 0;

        /// <summary>
        /// 父母となる武将のID (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public ushort Parents { get; set; } = 0;

        /// <summary>
        /// 祖父母となる武将のID (武将と汎用ライバルとイベント人物のみ)
        /// </summary>
        public ushort Grandparents { get; set; } = 0;

        /// <summary>
        /// 妻となる武将のID。妻側での夫の設定は不要。
        /// (武将のみ設定可)
        /// </summary>
        public ushort Spouse { get; set; } = 0;

        /// <summary>
        /// 武芸師匠となる武将のID (武将のみ設定可)
        /// </summary>
        public ushort Master { get; set; } = 0;

        /// <summary>
        /// 所属流派 (武将のみ設定可)
        /// </summary>
        public byte Ryuha { get; set; } = 0;

        /// <summary>
        /// 印可状（武将と汎用ライバルのみ）
        /// </summary>
        public byte License { get; set; } = 0;

        /// <summary>
        /// 関係者経緯。0円満、1主人公が裏切った、2この武将が裏切った、3その他。
        /// （武将と汎用ライバルのみ）
        /// </summary>
        public byte BetrayalFlag { get; set; } = 0;

        /// <summary>
        /// 元配下フラグ。0無関係、1元配下、2元上司、3元同僚。
        /// （武将と汎用ライバルのみ）
        /// </summary>
        public byte PreviousRelationship { get; set; } = 0;

        #endregion

        #region プロパティ：状態フラグ
        /// <summary>
        /// 登場フラグ
        /// </summary>
        public bool TojoFlag
        {
            get { return (State1 & 0x80) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x80 : 0);
                byte mask = 0xFF ^ 0x80;
                byte maskedState = (byte)(State1 & mask);
                State1 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 死亡フラグ
        /// </summary>
        public bool DeadFlag
        {
            get { return (State1 & 0x02) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x02 : 0);
                byte mask = 0xFF ^ 0x02;
                byte maskedState = (byte)(State1 & mask);
                State1 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 神隠しフラグ1
        /// </summary>
        public bool KamikakushiFlag1
        {
            get { return (State3 & 0x02) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x02 : 0);
                byte mask = 0xFF ^ 0x02;
                byte maskedState = (byte)(State3 & mask);
                State3 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 神隠しフラグ2
        /// </summary>
        public bool KamikakushiFlag2
        {
            get { return (State2 & 0x01) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x01 : 0);
                byte mask = 0xFF ^ 0x01;
                byte maskedState = (byte)(State2 & mask);
                State2 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 面識フラグ
        /// </summary>
        public bool MenshikiFlag
        {
            get { return (State1 & 0x40) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x40 : 0);
                byte mask = 0xFF ^ 0x40;
                byte maskedState = (byte)(State1 & mask);
                State1 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 好みフラグ
        /// </summary>
        public bool KonomiFlag
        {
            get { return (State1 & 0x10) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x10 : 0);
                byte mask = 0xFF ^ 0x10;
                byte maskedState = (byte)(State1 & mask);
                State1 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 元服フラグ
        /// </summary>
        public bool GenpukuFlag
        {
            get { return (State3 & 0x04) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x04 : 0);
                byte mask = 0xFF ^ 0x04;
                byte maskedState = (byte)(State3 & mask);
                State3 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 病フラグ
        /// </summary>
        public bool YamaiFlag
        {
            get { return (State1 & 0x01) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x01 : 0);
                byte mask = 0xFF ^ 0x01;
                byte maskedState = (byte)(State1 & mask);
                State1 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 恨みフラグ
        /// </summary>
        public bool UramiFlag
        {
            get { return (State2 & 0x40) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x40 : 0);
                byte mask = 0xFF ^ 0x40;
                byte maskedState = (byte)(State2 & mask);
                State2 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 不在フラグ
        /// </summary>
        public bool HuzaiFlag
        {
            get { return (State1 & 0x04) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x04 : 0);
                byte mask = 0xFF ^ 0x04;
                byte maskedState = (byte)(State1 & mask);
                State1 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 出陣フラグ
        /// </summary>
        public bool ShutujinFlag
        {
            get { return (State4 & 0x01) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x01 : 0);
                byte mask = 0xFF ^ 0x01;
                byte maskedState = (byte)(State4 & mask);
                State4 = (byte)(maskedState | flag);
            }
        }

        /// <summary>
        /// 外出禁止フラグ
        /// </summary>
        public bool GaishutuKinshiFlag
        {
            get { return (State3 & 0x01) != 0; }
            set
            {
                byte flag = (byte)(value ? 0x01 : 0);
                byte mask = 0xFF ^ 0x01;
                byte maskedState = (byte)(State3 & mask);
                State3 = (byte)(maskedState | flag);
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 武将のコンストラクタ
        /// </summary>
        public Busho()
        {
        }

        #endregion

        #region ToString実装
        /// <summary>
        /// オブジェクトを文字列にして返す
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return ID + ": " + FamilyName + GivenName;
        }

        #endregion

    }
}
