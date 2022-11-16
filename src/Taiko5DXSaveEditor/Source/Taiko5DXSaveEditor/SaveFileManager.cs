using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;
using Taiko5DXSaveEditor.GameObjects;

namespace Taiko5DXSaveEditor
{
    /// <summary>
    /// セーブファイル管理者。
    /// セーブファイルの読み書きを行う。
    /// </summary>
    public class SaveFileManager
    {
        #region 定数
        /// <summary>
        /// ファイルの総バイト数
        /// </summary>
        private static readonly int FILE_SIZE = 0x00086182;

        /// <summary>
        /// 名前リストのフォルダ
        /// </summary>
        private static readonly string NAME_LISTS_DIRECTORY = @"Data/NameLists/";

        /// <summary>
        /// アドレスリストのフォルダ
        /// </summary>
        private static readonly string ADDRESS_LISTS_DIRECTORY = @"Data/AddressLists/";

        /// <summary>
        /// アイテム情報のファイルのパス
        /// </summary>
        private static readonly string ITEM_DATA_FILE_PATH = @"Data/StaticData/ItemData.json";

        #endregion

        #region フィールド
        /// <summary>
        /// セーブファイルのバイナリ
        /// </summary>
        private byte[] _Bytes = null;

        /// <summary>
        /// チェックサム
        /// </summary>
        private int _Checksum = 0;

        /// <summary>
        /// 書き換え対象部分のみの部分的なチェックサム(編集前)
        /// </summary>
        private int _PartOfChecksumBefore = 0;

        /// <summary>
        /// 書き換え対象部分のみの部分的なチェックサム(編集後)
        /// </summary>
        private int _PartOfChecksumAfter = 0;

        /// <summary>
        /// 名前リストの辞書。
        /// キーはファイル名から拡張子を除いたもの。値は名前リスト。
        /// </summary>
        private Dictionary<string, List<string>> _NameListDictionary = new Dictionary<string, List<string>>();

        /// <summary>
        /// アドレス情報の辞書。
        /// キーはデータ名。値はアドレス情報。
        /// </summary>
        private Dictionary<string, AddressInfo> _AddressDictionary = new Dictionary<string, AddressInfo>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// セーブファイル管理者のコンストラクタ
        /// </summary>
        public SaveFileManager()
        {
            LoadNameLists();
            LoadAddressLists();
        }

        #endregion

        #region 名前リスト・アドレスリスト関連のメソッド
        /// <summary>
        /// 名前リストの読み込み
        /// </summary>
        private void LoadNameLists()
        {
            // 名前リストを読み込み、辞書を作成する
            var filePaths = Directory.GetFiles(NAME_LISTS_DIRECTORY, "*.txt");
            foreach (string path in filePaths)
            {
                // ファイルから名前リストを作る
                var list = new List<string>();
                using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    string line = "";
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string name = line.Trim();
                        if (name != "")
                        {
                            list.Add(name);
                        }
                    }
                }
                // 名前リストを辞書に登録する
                string key = Path.GetFileNameWithoutExtension(path);
                _NameListDictionary[key] = list;
            }
        }

        /// <summary>
        /// アドレスリストの読み込み
        /// </summary>
        private void LoadAddressLists()
        {
            // アドレスリストを読み込み、辞書を作成する
            var filePaths = Directory.GetFiles(ADDRESS_LISTS_DIRECTORY, "*.json");
            foreach (string path in filePaths)
            {
                string text = "";
                using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }
                var infos = JsonSerializer.Deserialize<List<AddressInfo>>(text);
                foreach (var info in infos)
                {
                    _AddressDictionary[info.DataName] = info;
                }
            }
        }

        #endregion

        #region セーブファイルの読み書きメソッド
        /// <summary>
        /// セーブファイルを読み込んで、ゲームデータを返す
        /// </summary>
        /// <param name="filePath">読み込むファイルのパス</param>
        /// <returns>ゲームデータ</returns>
        public GameData ReadSaveFile(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // ファイルサイズチェック
                if (fileStream.Length != FILE_SIZE)
                {
                    throw new Exception("ファイルサイズが想定外です");
                }
                // ファイルの読み込み
                byte[] bytes = new byte[FILE_SIZE];
                fileStream.Read(bytes, 0, FILE_SIZE);
                _Bytes = bytes;
            }

            // 読み込んだ内容からゲームデータを解釈する
            GameData gameData = new GameData(_NameListDictionary);
            // チェックサムの読み込み
            _Checksum = (int)ReadIntegerData("Checksum", 0);
            _PartOfChecksumBefore = 0;
            _PartOfChecksumAfter = 0;
            // データの読み込み
            gameData.World = ReadWorldData();
            gameData.Shujinko = ReadShujinkoData();
            gameData.BushoList = ReadBushoData();
            gameData.SeiryokuList = ReadSeiryokuData(gameData.BushoList, gameData.Shujinko);
            gameData.KyotenList = ReadKyotenData();
            gameData.ItemList = ReadItemData();
            gameData.HanroList = ReadHanroData();
            gameData.ShokenList = ReadShokenData();
            gameData.RyuhaList = ReadRyuhaData(gameData.Shujinko);
            gameData.KaniList = ReadKaniData();

            // 結果を返す
            return gameData;
        }

        /// <summary>
        /// 渡されたゲームデータから、セーブファイルの書き込みを行う
        /// </summary>
        /// <param name="filePath">読み込むファイルのパス</param>
        /// <param name="gameData">ゲームデータ</param>
        public void WriteSaveFile(string filePath, GameData gameData)
        {
            // 念のために初期化
            _PartOfChecksumAfter = 0;

            // データの書き込み
            WriteWorldData(gameData);
            WriteShujinkoData(gameData);
            WriteBushoData(gameData);
            WriteSeiryokuData(gameData);
            WriteKyotenData(gameData);
            WriteItemData(gameData);
            WriteHanroData(gameData);
            WriteShokenData(gameData);
            WriteRyuhaData(gameData);
            WriteKaniData(gameData);
            // チェックサムの更新
            int checksumOffset = _PartOfChecksumAfter - _PartOfChecksumBefore;
            _PartOfChecksumBefore = _PartOfChecksumAfter;
            _Checksum += checksumOffset;
            WriteIntegerData("Checksum", (ulong)_Checksum, 0);
            _PartOfChecksumAfter = 0;

            // ファイル書き込み
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                fileStream.Write(_Bytes, 0, FILE_SIZE);
            }
        }

        /// <summary>
        /// 世界データの読み取り
        /// </summary>
        /// <returns>世界データ</returns>
        private World ReadWorldData()
        {
            World result = new World();
            result.ScenarioNumber = (byte)ReadIntegerData("World.ScenarioNumber", 0);
            result.Year = (byte)ReadIntegerData("World.Year", 0);
            result.Month = (byte)ReadIntegerData("World.Month", 0);
            result.Day = (byte)ReadIntegerData("World.Day", 0);
            result.Time = (byte)ReadIntegerData("World.Time", 0);
            result.PlayDays = (ushort)ReadIntegerData("World.PlayDays", 0);
            result.NextMeetingDays = (byte)ReadIntegerData("World.NextMeetingDays", 0);
            return result;
        }

        /// <summary>
        /// 世界データの書き込み
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        private void WriteWorldData(GameData gameData)
        {
            World world = gameData.World;
            WriteIntegerData("World.ScenarioNumber", world.ScenarioNumber, 0);
            WriteIntegerData("World.Year", world.Year, 0);
            WriteIntegerData("World.Month", world.Month, 0);
            WriteIntegerData("World.Day", world.Day, 0);
            WriteIntegerData("World.Time", world.Time, 0);
            WriteIntegerData("World.PlayDays", world.PlayDays, 0);
            WriteIntegerData("World.NextMeetingDays", world.NextMeetingDays, 0);
        }

        /// <summary>
        /// 主人公データの読み取り
        /// </summary>
        /// <returns>主人公データ</returns>
        private Shujinko ReadShujinkoData()
        {
            Shujinko result = new Shujinko();
            result.ShujinkoID = (ushort)ReadIntegerData("Shujinko.ID", 0);
            result.Face1 = (ushort)ReadIntegerData("Shujinko.Face1", 0);
            result.Face2 = (ushort)ReadIntegerData("Shujinko.Face2", 0);
            result.Face3 = (ushort)ReadIntegerData("Shujinko.Face3", 0);
            result.Face4 = (ushort)ReadIntegerData("Shujinko.Face4", 0);
            result.HitPoint = (byte)ReadIntegerData("Shujinko.HitPoint", 0);
            result.Weapon = (ushort)ReadIntegerData("Shujinko.Weapon", 0);
            result.Armor = (ushort)ReadIntegerData("Shujinko.Armor", 0);
            result.Money = (uint)ReadIntegerData("Shujinko.Money", 0);
            result.Bank = (uint)ReadIntegerData("Shujinko.Bank", 0);
            result.Herbs = (ushort)ReadIntegerData("Shujinko.Herbs", 0);
            result.IronSands = (ushort)ReadIntegerData("Shujinko.IronSands", 0);
            result.ExpMedical = (uint)ReadIntegerData("Shujinko.ExpMedical", 0);
            result.NumOfFreeConsultations = (uint)ReadIntegerData("Shujinko.NumOfFreeConsultations", 0);
            result.DaysOfCompounding = (uint)ReadIntegerData("Shujinko.DaysOfCompounding", 0);
            result.DaysOfGettingHerbs = (uint)ReadIntegerData("Shujinko.DaysOfGettingHerbs", 0);
            result.NumOfTeaCeremonys = (uint)ReadIntegerData("Shujinko.NumOfTeaCeremonys", 0);
            result.ExpTeaSetCraft = (uint)ReadIntegerData("Shujinko.ExpTeaSetCraft", 0);
            result.ExpGunpowderCraft = (ushort)ReadIntegerData("Shujinko.ExpGunpowderCraft", 0);
            result.ExpIronCraft = (ushort)ReadIntegerData("Shujinko.ExpIronCraft", 0);
            result.ExpWeaponCraft = (ushort)ReadIntegerData("Shujinko.ExpWeaponCraft", 0);
            result.ExpGunCraft = (ushort)ReadIntegerData("Shujinko.ExpGunCraft", 0);
            result.ExpMeditation = (ushort)ReadIntegerData("Shujinko.ExpMeditation", 0);
            result.NumOfWins = (uint)ReadIntegerData("Shujinko.NumOfWins", 0);
            result.NumOfConsecutiveWins = (uint)ReadIntegerData("Shujinko.NumOfConsecutiveWins", 0);
            result.NumOfDefeats = (uint)ReadIntegerData("Shujinko.NumOfDefeats", 0);
            result.NumOfWinsWithSword = (byte)ReadIntegerData("Shujinko.NumOfWinsWithSword", 0);
            result.NumOfWinsWithSpear = (byte)ReadIntegerData("Shujinko.NumOfWinsWithSpear", 0);
            result.NumOfWinsWithKunai = (byte)ReadIntegerData("Shujinko.NumOfWinsWithKunai", 0);
            result.NumOfWinsWithKusarigama = (byte)ReadIntegerData("Shujinko.NumOfWinsWithKusarigama", 0);
            result.NumOfWinsWithGun = (byte)ReadIntegerData("Shujinko.NumOfWinsWithGun", 0);
            result.NumOfWinsWithBow = (byte)ReadIntegerData("Shujinko.NumOfWinsWithBow", 0);
            result.MeishoCardFlags = (ulong)ReadIntegerData("Shujinko.MeishoCardFlags", 0);
            result.OtherCardFlags = (ulong)ReadIntegerData("Shujinko.OtherCardFlags", 0);
            result.SkillExpInfantry = (byte)ReadIntegerData("Shujinko.SkillExpInfantry", 0);
            result.SkillExpCavalry = (byte)ReadIntegerData("Shujinko.SkillExpCavalry", 0);
            result.SkillExpGun = (byte)ReadIntegerData("Shujinko.SkillExpGun", 0);
            result.SkillExpNavy = (byte)ReadIntegerData("Shujinko.SkillExpNavy", 0);
            result.SkillExpArchery = (byte)ReadIntegerData("Shujinko.SkillExpArchery", 0);
            result.SkillExpMartialArts = (byte)ReadIntegerData("Shujinko.SkillExpMartialArts", 0);
            result.SkillExpTactics = (byte)ReadIntegerData("Shujinko.SkillExpTactics", 0);
            result.SkillExpNinjutsu = (byte)ReadIntegerData("Shujinko.SkillExpNinjutsu", 0);
            result.SkillExpBuilding = (byte)ReadIntegerData("Shujinko.SkillExpBuilding", 0);
            result.SkillExpAgriculture = (byte)ReadIntegerData("Shujinko.SkillExpAgriculture", 0);
            result.SkillExpMine = (byte)ReadIntegerData("Shujinko.SkillExpMine", 0);
            result.SkillExpMath = (byte)ReadIntegerData("Shujinko.SkillExpMath", 0);
            result.SkillExpCourtesy = (byte)ReadIntegerData("Shujinko.SkillExpCourtesy", 0);
            result.SkillExpSpeech = (byte)ReadIntegerData("Shujinko.SkillExpSpeech", 0);
            result.SkillExpTeaCeremony = (byte)ReadIntegerData("Shujinko.SkillExpTeaCeremony", 0);
            result.SkillExpMedical = (byte)ReadIntegerData("Shujinko.SkillExpMedical", 0);
            result.ShogoExpDomesticAffairs = (uint)ReadIntegerData("Shujinko.ShogoExpDomesticAffairs", 0);
            result.ShogoExpDiplomacy = (uint)ReadIntegerData("Shujinko.ShogoExpDiplomacy", 0);
            result.ShogoNumOfWarWin = (uint)ReadIntegerData("Shujinko.ShogoNumOfWarWin", 0);
            result.ShogoNumOfKill = (byte)ReadIntegerData("Shujinko.ShogoNumOfKill", 0);
            result.ShogoNumOfRebellion = (byte)ReadIntegerData("Shujinko.ShogoNumOfRebellion", 0);
            result.ShogoNumOfRecruiting = (byte)ReadIntegerData("Shujinko.ShogoNumOfRecruiting", 0);
            result.ShogoNumOfAppraisal = (byte)ReadIntegerData("Shujinko.ShogoNumOfAppraisal", 0);
            result.ShogoNumOfArtAcceptance = (byte)ReadIntegerData("Shujinko.ShogoNumOfArtAcceptance", 0);
            result.ShogoNumOfBetrayal = (byte)ReadIntegerData("Shujinko.ShogoNumOfBetrayal", 0);
            result.ShogoNumOfDevelopment = (byte)ReadIntegerData("Shujinko.ShogoNumOfDevelopment", 0);
            result.ShogoNumOfWorkInBar = (byte)ReadIntegerData("Shujinko.ShogoNumOfWorkInBar", 0);
            result.NameOfMyRyuha = ReadStringData("Shujinko.NameOfMyRyuha", 0);
            result.KanaOfMyRyuha = ReadStringData("Shujinko.KanaOfMyRyuha", 0);
            result.NameOfMyShoka = ReadStringData("Shujinko.NameOfMyShoka", 0);
            result.KanaOfMyShoka = ReadStringData("Shujinko.KanaOfMyShoka", 0);
            result.Rival = (ushort)ReadIntegerData("Shujinko.Rival", 0);
            result.DojoMoney = (ushort)ReadIntegerData("Shujinko.DojoMoney", 0);
            result.NumOfDisciples = (ushort)ReadIntegerData("Shujinko.NumOfDisciples", 0);
            result.InstructionDaimyoke = (byte)ReadIntegerData("Shujinko.InstructionDaimyoke", 0);
            result.InstructionCounter = (byte)ReadIntegerData("Shujinko.InstructionCounter", 0);
            result.BodyguardRank = (byte)ReadIntegerData("Shujinko.BodyguardRank", 0);
            result.BodyguardDays = (byte)ReadIntegerData("Shujinko.BodyguardDays", 0);
            result.WifeAffection = (byte)ReadIntegerData("Shujinko.WifeAffection", 0);
            return result;
        }

        /// <summary>
        /// 主人公データの書き込み
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        private void WriteShujinkoData(GameData gameData)
        {
            Shujinko shujinko = gameData.Shujinko;
            WriteIntegerData("Shujinko.ID", shujinko.ShujinkoID, 0);
            WriteIntegerData("Shujinko.Face1", shujinko.Face1, 0);
            WriteIntegerData("Shujinko.Face2", shujinko.Face2, 0);
            WriteIntegerData("Shujinko.Face3", shujinko.Face3, 0);
            WriteIntegerData("Shujinko.Face4", shujinko.Face4, 0);
            WriteIntegerData("Shujinko.HitPoint", shujinko.HitPoint, 0);
            WriteIntegerData("Shujinko.Weapon", shujinko.Weapon, 0);
            WriteIntegerData("Shujinko.Armor", shujinko.Armor, 0);
            WriteIntegerData("Shujinko.Money", shujinko.Money, 0);
            WriteIntegerData("Shujinko.Bank", shujinko.Bank, 0);
            WriteIntegerData("Shujinko.Herbs", shujinko.Herbs, 0);
            WriteIntegerData("Shujinko.IronSands", shujinko.IronSands, 0);
            WriteIntegerData("Shujinko.ExpMedical", shujinko.ExpMedical, 0);
            WriteIntegerData("Shujinko.NumOfFreeConsultations", shujinko.NumOfFreeConsultations, 0);
            WriteIntegerData("Shujinko.DaysOfCompounding", shujinko.DaysOfCompounding, 0);
            WriteIntegerData("Shujinko.DaysOfGettingHerbs", shujinko.DaysOfGettingHerbs, 0);
            WriteIntegerData("Shujinko.NumOfTeaCeremonys", shujinko.NumOfTeaCeremonys, 0);
            WriteIntegerData("Shujinko.ExpTeaSetCraft", shujinko.ExpTeaSetCraft, 0);
            WriteIntegerData("Shujinko.ExpGunpowderCraft", shujinko.ExpGunpowderCraft, 0);
            WriteIntegerData("Shujinko.ExpIronCraft", shujinko.ExpIronCraft, 0);
            WriteIntegerData("Shujinko.ExpWeaponCraft", shujinko.ExpWeaponCraft, 0);
            WriteIntegerData("Shujinko.ExpGunCraft", shujinko.ExpGunCraft, 0);
            WriteIntegerData("Shujinko.ExpMeditation", shujinko.ExpMeditation, 0);
            WriteIntegerData("Shujinko.NumOfWins", shujinko.NumOfWins, 0);
            WriteIntegerData("Shujinko.NumOfConsecutiveWins", shujinko.NumOfConsecutiveWins, 0);
            WriteIntegerData("Shujinko.NumOfDefeats", shujinko.NumOfDefeats, 0);
            WriteIntegerData("Shujinko.NumOfWinsWithSword", shujinko.NumOfWinsWithSword, 0);
            WriteIntegerData("Shujinko.NumOfWinsWithSpear", shujinko.NumOfWinsWithSpear, 0);
            WriteIntegerData("Shujinko.NumOfWinsWithKunai", shujinko.NumOfWinsWithKunai, 0);
            WriteIntegerData("Shujinko.NumOfWinsWithKusarigama", shujinko.NumOfWinsWithKusarigama, 0);
            WriteIntegerData("Shujinko.NumOfWinsWithGun", shujinko.NumOfWinsWithGun, 0);
            WriteIntegerData("Shujinko.NumOfWinsWithBow", shujinko.NumOfWinsWithBow, 0);
            WriteIntegerData("Shujinko.MeishoCardFlags", shujinko.MeishoCardFlags, 0);
            WriteIntegerData("Shujinko.OtherCardFlags", shujinko.OtherCardFlags, 0);
            WriteIntegerData("Shujinko.SkillExpInfantry", shujinko.SkillExpInfantry, 0);
            WriteIntegerData("Shujinko.SkillExpCavalry", shujinko.SkillExpCavalry, 0);
            WriteIntegerData("Shujinko.SkillExpGun", shujinko.SkillExpGun, 0);
            WriteIntegerData("Shujinko.SkillExpNavy", shujinko.SkillExpNavy, 0);
            WriteIntegerData("Shujinko.SkillExpArchery", shujinko.SkillExpArchery, 0);
            WriteIntegerData("Shujinko.SkillExpMartialArts", shujinko.SkillExpMartialArts, 0);
            WriteIntegerData("Shujinko.SkillExpTactics", shujinko.SkillExpTactics, 0);
            WriteIntegerData("Shujinko.SkillExpNinjutsu", shujinko.SkillExpNinjutsu, 0);
            WriteIntegerData("Shujinko.SkillExpBuilding", shujinko.SkillExpBuilding, 0);
            WriteIntegerData("Shujinko.SkillExpAgriculture", shujinko.SkillExpAgriculture, 0);
            WriteIntegerData("Shujinko.SkillExpMine", shujinko.SkillExpMine, 0);
            WriteIntegerData("Shujinko.SkillExpMath", shujinko.SkillExpMath, 0);
            WriteIntegerData("Shujinko.SkillExpCourtesy", shujinko.SkillExpCourtesy, 0);
            WriteIntegerData("Shujinko.SkillExpSpeech", shujinko.SkillExpSpeech, 0);
            WriteIntegerData("Shujinko.SkillExpTeaCeremony", shujinko.SkillExpTeaCeremony, 0);
            WriteIntegerData("Shujinko.SkillExpMedical", shujinko.SkillExpMedical, 0);
            WriteIntegerData("Shujinko.ShogoExpDomesticAffairs", shujinko.ShogoExpDomesticAffairs, 0);
            WriteIntegerData("Shujinko.ShogoExpDiplomacy", shujinko.ShogoExpDiplomacy, 0);
            WriteIntegerData("Shujinko.ShogoNumOfWarWin", shujinko.ShogoNumOfWarWin, 0);
            WriteIntegerData("Shujinko.ShogoNumOfKill", shujinko.ShogoNumOfKill, 0);
            WriteIntegerData("Shujinko.ShogoNumOfRebellion", shujinko.ShogoNumOfRebellion, 0);
            WriteIntegerData("Shujinko.ShogoNumOfRecruiting", shujinko.ShogoNumOfRecruiting, 0);
            WriteIntegerData("Shujinko.ShogoNumOfAppraisal", shujinko.ShogoNumOfAppraisal, 0);
            WriteIntegerData("Shujinko.ShogoNumOfArtAcceptance", shujinko.ShogoNumOfArtAcceptance, 0);
            WriteIntegerData("Shujinko.ShogoNumOfBetrayal", shujinko.ShogoNumOfBetrayal, 0);
            WriteIntegerData("Shujinko.ShogoNumOfDevelopment", shujinko.ShogoNumOfDevelopment, 0);
            WriteIntegerData("Shujinko.ShogoNumOfWorkInBar", shujinko.ShogoNumOfWorkInBar, 0);
            WriteStringData("Shujinko.NameOfMyRyuha", shujinko.NameOfMyRyuha, 0);
            WriteStringData("Shujinko.KanaOfMyRyuha", shujinko.KanaOfMyRyuha, 0);
            WriteStringData("Shujinko.NameOfMyShoka", shujinko.NameOfMyShoka, 0);
            WriteStringData("Shujinko.KanaOfMyShoka", shujinko.KanaOfMyShoka, 0);
            WriteIntegerData("Shujinko.Rival", shujinko.Rival, 0);
            WriteIntegerData("Shujinko.DojoMoney", shujinko.DojoMoney, 0);
            WriteIntegerData("Shujinko.NumOfDisciples", shujinko.NumOfDisciples, 0);
            WriteIntegerData("Shujinko.InstructionDaimyoke", shujinko.InstructionDaimyoke, 0);
            WriteIntegerData("Shujinko.InstructionCounter", shujinko.InstructionCounter, 0);
            WriteIntegerData("Shujinko.BodyguardRank", shujinko.BodyguardRank, 0);
            WriteIntegerData("Shujinko.BodyguardDays", shujinko.BodyguardDays, 0);
            WriteIntegerData("Shujinko.WifeAffection", shujinko.WifeAffection, 0);
        }

        /// <summary>
        /// 武将データの読み取り
        /// </summary>
        /// <returns>武将データ</returns>
        private List<Busho> ReadBushoData()
        {
            // 結果として返す武将リスト
            List<Busho> bushoList = new List<Busho>();

            // 読み取り
            int n = GameData.NumOfPeople;
            for (int i = 0; i < n; ++i)
            {
                Busho busho = new Busho();
                // IDと人物カテゴリの設定
                busho.ID = i;
                if (busho.ID < GameData.NumOfBusho)
                    busho.PeopleCategory = PeopleCategory.Busho;
                else if (busho.ID < (GameData.NumOfBusho + GameData.NumOfGeneralPurpose))
                    busho.PeopleCategory = PeopleCategory.GeneralPurpose;
                else if (busho.ID < (GameData.NumOfBusho + GameData.NumOfGeneralPurpose + GameData.NumOfEventPerson))
                    busho.PeopleCategory = PeopleCategory.EventPerson;
                else if (busho.ID < (GameData.NumOfBusho + GameData.NumOfGeneralPurpose + GameData.NumOfEventPerson + GameData.NumOfCitizen))
                    busho.PeopleCategory = PeopleCategory.Citizen;
                else
                    busho.PeopleCategory = PeopleCategory.Invalid;

                // 読み取り(武将のみ)
                if (busho.PeopleCategory == PeopleCategory.Busho)
                {
                    busho.YearOfDeath = (byte)ReadIntegerData("Busho.YearOfDeath", i);
                    busho.Kani = (byte)ReadIntegerData("Busho.Kani", i);
                    busho.Ryuha = (byte)ReadIntegerData("Busho.Ryuha", i);
                    busho.Master = (ushort)ReadIntegerData("Busho.Master", i);
                    busho.BushiAchievement = (ushort)ReadIntegerData("Busho.BushiAchievement", i);
                    busho.Spouse = (ushort)ReadIntegerData("Busho.Spouse", i);
                }
                // 読み取り(武将と汎用ライバルのみ)
                if ((busho.PeopleCategory == PeopleCategory.Busho) || (busho.PeopleCategory == PeopleCategory.GeneralPurpose))
                {
                    busho.Formation = (byte)ReadIntegerData("Busho.Formation", i);
                    busho.Preference = (byte)ReadIntegerData("Busho.Preference", i);
                    busho.Desire = (byte)ReadIntegerData("Busho.Desire", i);
                    busho.Drinking = (byte)ReadIntegerData("Busho.Drinking", i);
                    busho.Temper = (byte)ReadIntegerData("Busho.Temper", i);
                    busho.Honor = (byte)ReadIntegerData("Busho.Honor", i);
                    busho.Spirit = (byte)ReadIntegerData("Busho.Spirit", i);
                    busho.Ism = (byte)ReadIntegerData("Busho.Ism", i);
                    busho.Behavior = (byte)ReadIntegerData("Busho.Behavior", i);
                    busho.Occupation = (byte)ReadIntegerData("Busho.Occupation", i);
                    busho.SeiryokuCompatibility = (byte)ReadIntegerData("Busho.SeiryokuCompatibility", i);
                    busho.Compatibility = (byte)ReadIntegerData("Busho.Compatibility", i);
                    busho.Fame = (byte)ReadIntegerData("Busho.Fame", i);
                    busho.Notorious = (byte)ReadIntegerData("Busho.Notorious", i);
                    busho.ShoninAchievement = (ushort)ReadIntegerData("Busho.ShoninAchievement", i);
                    busho.NinjaAchievement = (ushort)ReadIntegerData("Busho.NinjaAchievement", i);
                    busho.KaizokuAchievement = (ushort)ReadIntegerData("Busho.KaizokuAchievement", i);
                    busho.Leadership = (byte)ReadIntegerData("Busho.Leadership", i);
                    busho.CombatPower = (byte)ReadIntegerData("Busho.CombatPower", i);
                    busho.Politics = (byte)ReadIntegerData("Busho.Politics", i);
                    busho.Intellect = (byte)ReadIntegerData("Busho.Intellect", i);
                    busho.Charm = (byte)ReadIntegerData("Busho.Charm", i);
                    busho.Seiryoku = (byte)ReadIntegerData("Busho.Seiryoku", i);
                    busho.BetrayalFlag = (byte)ReadIntegerData("Busho.BetrayalFlag", i);
                    busho.Origin = (byte)ReadIntegerData("Busho.Origin", i);
                    busho.Tachiba = (byte)ReadIntegerData("Busho.Tachiba", i);
                    busho.Luck = (byte)ReadIntegerData("Busho.Luck", i);
                    busho.State4 = (byte)ReadIntegerData("Busho.State4", i);
                    busho.PreviousRelationship = (byte)ReadIntegerData("Busho.PreviousRelationship", i);
                    busho.CauseOfDeath = (byte)ReadIntegerData("Busho.CauseOfDeath", i);
                    busho.WeaponType = (byte)ReadIntegerData("Busho.WeaponType", i);
                    busho.License = (byte)ReadIntegerData("Busho.License", i);
                    busho.Boss = (ushort)ReadIntegerData("Busho.Boss", i);
                    busho.Salary = (ushort)ReadIntegerData("Busho.Salary", i);
                    busho.Ambition = (byte)ReadIntegerData("Busho.Ambition", i);
                    busho.Loyalty = (byte)ReadIntegerData("Busho.Loyalty", i);
                    busho.HigiCardFlags = ReadBytesData("Busho.HigiCardFlags", i);
                    busho.ShogoCardFlags = ReadBytesData("Busho.ShogoCardFlags", i);
                    busho.KassenCardFlags = ReadBytesData("Busho.KassenCardFlags", i);
                }
                // 読み取り(武将と汎用ライバルとイベント人物のみ)
                if ((busho.PeopleCategory == PeopleCategory.Busho) || (busho.PeopleCategory == PeopleCategory.GeneralPurpose) || (busho.PeopleCategory == PeopleCategory.EventPerson))
                {
                    busho.KanaOfFamilyName = ReadStringData("Busho.KanaOfFamilyName", i);
                    busho.KanaOfGivenName = ReadStringData("Busho.KanaOfGivenName", i);
                    busho.State1 = (byte)ReadIntegerData("Busho.State1", i);
                    busho.Kyoten = (ushort)ReadIntegerData("Busho.Kyoten", i);
                    busho.State2 = (byte)ReadIntegerData("Busho.State2", i);
                    busho.State3 = (byte)ReadIntegerData("Busho.State3", i);
                    busho.SkillInfantry = (byte)ReadIntegerData("Busho.SkillInfantry", i);
                    busho.SkillCavalry = (byte)ReadIntegerData("Busho.SkillCavalry", i);
                    busho.SkillGun = (byte)ReadIntegerData("Busho.SkillGun", i);
                    busho.SkillNavy = (byte)ReadIntegerData("Busho.SkillNavy", i);
                    busho.SkillArchery = (byte)ReadIntegerData("Busho.SkillArchery", i);
                    busho.SkillMartialArts = (byte)ReadIntegerData("Busho.SkillMartialArts", i);
                    busho.SkillTactics = (byte)ReadIntegerData("Busho.SkillTactics", i);
                    busho.SkillNinjutsu = (byte)ReadIntegerData("Busho.SkillNinjutsu", i);
                    busho.SkillBuilding = (byte)ReadIntegerData("Busho.SkillBuilding", i);
                    busho.SkillAgriculture = (byte)ReadIntegerData("Busho.SkillAgriculture", i);
                    busho.SkillMine = (byte)ReadIntegerData("Busho.SkillMine", i);
                    busho.SkillMath = (byte)ReadIntegerData("Busho.SkillMath", i);
                    busho.SkillCourtesy = (byte)ReadIntegerData("Busho.SkillCourtesy", i);
                    busho.SkillSpeech = (byte)ReadIntegerData("Busho.SkillSpeech", i);
                    busho.SkillTeaCeremony = (byte)ReadIntegerData("Busho.SkillTeaCeremony", i);
                    busho.SkillMedical = (byte)ReadIntegerData("Busho.SkillMedical", i);
                    busho.Parents = (ushort)ReadIntegerData("Busho.Parents", i);
                    busho.Grandparents = (ushort)ReadIntegerData("Busho.Grandparents", i);
                    busho.YearOfBirth = (byte)ReadIntegerData("Busho.YearOfBirth", i);
                    busho.YearOfAdult = (byte)ReadIntegerData("Busho.YearOfAdult", i);
                    busho.Closeness = (byte)ReadIntegerData("Busho.Closeness", i);
                }
                // 全員読み取ってよいデータ
                busho.FamilyName = ReadStringData("Busho.FamilyName", i);
                busho.GivenName = ReadStringData("Busho.GivenName", i);
                busho.Mibun = (byte)ReadIntegerData("Busho.Mibun", i);
                busho.Sex = (byte)ReadIntegerData("Busho.Sex", i);
                busho.WifePersonality = (byte)ReadIntegerData("Busho.WifePersonality", i);
                busho.Face1 = (ushort)ReadIntegerData("Busho.Face1", i);
                busho.Face2 = (ushort)ReadIntegerData("Busho.Face2", i);

                // 追加
                bushoList.Add(busho);
            }

            return bushoList;
        }

        /// <summary>
        /// 武将データの書き込み
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        private void WriteBushoData(GameData gameData)
        {
            // 武将リスト
            List<Busho> bushoList = gameData.BushoList;

            // 書き込み
            int n = GameData.NumOfPeople;
            for (int i = 0; i < n; ++i)
            {
                Busho busho = bushoList[i];

                // 書き込み(武将のみ)
                if (busho.PeopleCategory == PeopleCategory.Busho)
                {
                    WriteIntegerData("Busho.YearOfDeath", busho.YearOfDeath, i);
                    WriteIntegerData("Busho.Kani", busho.Kani, i);
                    WriteIntegerData("Busho.Ryuha", busho.Ryuha, i);
                    WriteIntegerData("Busho.Master", busho.Master, i);
                    WriteIntegerData("Busho.BushiAchievement", busho.BushiAchievement, i);
                    WriteIntegerData("Busho.Spouse", busho.Spouse, i);
                }
                // 書き込み(武将と汎用ライバルのみ)
                if ((busho.PeopleCategory == PeopleCategory.Busho) || (busho.PeopleCategory == PeopleCategory.GeneralPurpose))
                {
                    WriteIntegerData("Busho.Formation", busho.Formation, i);
                    WriteIntegerData("Busho.Preference", busho.Preference, i);
                    WriteIntegerData("Busho.Desire", busho.Desire, i);
                    WriteIntegerData("Busho.Drinking", busho.Drinking, i);
                    WriteIntegerData("Busho.Temper", busho.Temper, i);
                    WriteIntegerData("Busho.Honor", busho.Honor, i);
                    WriteIntegerData("Busho.Spirit", busho.Spirit, i);
                    WriteIntegerData("Busho.Ism", busho.Ism, i);
                    WriteIntegerData("Busho.Behavior", busho.Behavior, i);
                    WriteIntegerData("Busho.Occupation", busho.Occupation, i);
                    WriteIntegerData("Busho.SeiryokuCompatibility", busho.SeiryokuCompatibility, i);
                    WriteIntegerData("Busho.Compatibility", busho.Compatibility, i);
                    WriteIntegerData("Busho.Fame", busho.Fame, i);
                    WriteIntegerData("Busho.Notorious", busho.Notorious, i);
                    WriteIntegerData("Busho.ShoninAchievement", busho.ShoninAchievement, i);
                    WriteIntegerData("Busho.NinjaAchievement", busho.NinjaAchievement, i);
                    WriteIntegerData("Busho.KaizokuAchievement", busho.KaizokuAchievement, i);
                    WriteIntegerData("Busho.Leadership", busho.Leadership, i);
                    WriteIntegerData("Busho.CombatPower", busho.CombatPower, i);
                    WriteIntegerData("Busho.Politics", busho.Politics, i);
                    WriteIntegerData("Busho.Intellect", busho.Intellect, i);
                    WriteIntegerData("Busho.Charm", busho.Charm, i);
                    WriteIntegerData("Busho.Seiryoku", busho.Seiryoku, i);
                    WriteIntegerData("Busho.BetrayalFlag", busho.BetrayalFlag, i);
                    WriteIntegerData("Busho.Origin", busho.Origin, i);
                    WriteIntegerData("Busho.Tachiba", busho.Tachiba, i);
                    WriteIntegerData("Busho.Luck", busho.Luck, i);
                    WriteIntegerData("Busho.State4", busho.State4, i);
                    WriteIntegerData("Busho.PreviousRelationship", busho.PreviousRelationship, i);
                    WriteIntegerData("Busho.CauseOfDeath", busho.CauseOfDeath, i);
                    WriteIntegerData("Busho.WeaponType", busho.WeaponType, i);
                    WriteIntegerData("Busho.License", busho.License, i);
                    WriteIntegerData("Busho.Boss", busho.Boss, i);
                    WriteIntegerData("Busho.Salary", busho.Salary, i);
                    WriteIntegerData("Busho.Ambition", busho.Ambition, i);
                    WriteIntegerData("Busho.Loyalty", busho.Loyalty, i);
                    WriteBytesData("Busho.HigiCardFlags", busho.HigiCardFlags, i);
                    WriteBytesData("Busho.ShogoCardFlags", busho.ShogoCardFlags, i);
                    WriteBytesData("Busho.KassenCardFlags", busho.KassenCardFlags, i);
                }
                // 書き込み(武将と汎用ライバルとイベント人物のみ)
                if ((busho.PeopleCategory == PeopleCategory.Busho) || (busho.PeopleCategory == PeopleCategory.GeneralPurpose) || (busho.PeopleCategory == PeopleCategory.EventPerson))
                {
                    WriteStringData("Busho.KanaOfFamilyName", busho.KanaOfFamilyName, i);
                    WriteStringData("Busho.KanaOfGivenName", busho.KanaOfGivenName, i);
                    WriteIntegerData("Busho.State1", busho.State1, i);
                    WriteIntegerData("Busho.Kyoten", busho.Kyoten, i);
                    WriteIntegerData("Busho.State2", busho.State2, i);
                    WriteIntegerData("Busho.State3", busho.State3, i);
                    WriteIntegerData("Busho.SkillInfantry", busho.SkillInfantry, i);
                    WriteIntegerData("Busho.SkillCavalry", busho.SkillCavalry, i);
                    WriteIntegerData("Busho.SkillGun", busho.SkillGun, i);
                    WriteIntegerData("Busho.SkillNavy", busho.SkillNavy, i);
                    WriteIntegerData("Busho.SkillArchery", busho.SkillArchery, i);
                    WriteIntegerData("Busho.SkillMartialArts", busho.SkillMartialArts, i);
                    WriteIntegerData("Busho.SkillTactics", busho.SkillTactics, i);
                    WriteIntegerData("Busho.SkillNinjutsu", busho.SkillNinjutsu, i);
                    WriteIntegerData("Busho.SkillBuilding", busho.SkillBuilding, i);
                    WriteIntegerData("Busho.SkillAgriculture", busho.SkillAgriculture, i);
                    WriteIntegerData("Busho.SkillMine", busho.SkillMine, i);
                    WriteIntegerData("Busho.SkillMath", busho.SkillMath, i);
                    WriteIntegerData("Busho.SkillCourtesy", busho.SkillCourtesy, i);
                    WriteIntegerData("Busho.SkillSpeech", busho.SkillSpeech, i);
                    WriteIntegerData("Busho.SkillTeaCeremony", busho.SkillTeaCeremony, i);
                    WriteIntegerData("Busho.SkillMedical", busho.SkillMedical, i);
                    WriteIntegerData("Busho.Parents", busho.Parents, i);
                    WriteIntegerData("Busho.Grandparents", busho.Grandparents, i);
                    WriteIntegerData("Busho.YearOfBirth", busho.YearOfBirth, i);
                    WriteIntegerData("Busho.YearOfAdult", busho.YearOfAdult, i);
                    WriteIntegerData("Busho.Closeness", busho.Closeness, i);
                }
                // 全員書き込めるデータ
                WriteStringData("Busho.FamilyName", busho.FamilyName, i);
                WriteStringData("Busho.GivenName", busho.GivenName, i);
                WriteIntegerData("Busho.Mibun", busho.Mibun, i);
                WriteIntegerData("Busho.Sex", busho.Sex, i);
                WriteIntegerData("Busho.WifePersonality", busho.WifePersonality, i);
                WriteIntegerData("Busho.Face1", busho.Face1, i);
                WriteIntegerData("Busho.Face2", busho.Face2, i);
            }
        }

        /// <summary>
        /// 勢力データの読み取り
        /// </summary>
        /// <param name="bushoList">武将データ。大名家の名前付けのため。</param>
        /// <param name="shujinko">主人公データ。主人公商家の名前付けのため。</param>
        /// <returns>勢力データ</returns>
        private List<Seiryoku> ReadSeiryokuData(List<Busho> bushoList, Shujinko shujinko)
        {
            // 結果として返す勢力リスト
            List<Seiryoku> seiryokuList = new List<Seiryoku>();

            // 大名家の読み取り
            for (int i = 0; i < GameData.NumOfDaimyoke; ++i)
            {
                // 読み取り
                Daimyoke daimyoke = new Daimyoke();
                daimyoke.Ceasefire = ReadBytesData("Daimyoke.Ceasefire", i);
                daimyoke.JustCause = ReadBytesData("Daimyoke.JustCause", i);
                daimyoke.Diplomacy = ReadBytesData("Daimyoke.Diplomacy", i);
                daimyoke.DepartureCounter = (byte)ReadIntegerData("Daimyoke.DepartureCounter", i);
                daimyoke.RelationshipWithShujinko = (byte)ReadIntegerData("Daimyoke.RelationshipWithShujinko", i);
                daimyoke.FamilyCrest = (byte)ReadIntegerData("Daimyoke.FamilyCrest", i);
                daimyoke.InactivationFlag = (byte)ReadIntegerData("Daimyoke.InactivationFlag", i);
                daimyoke.Daihoshin = (byte)ReadIntegerData("Daimyoke.Daihoshin", i);
                daimyoke.Senryaku = (byte)ReadIntegerData("Daimyoke.Senryaku", i);
                daimyoke.Leader = (ushort)ReadIntegerData("Daimyoke.Leader", i);
                daimyoke.ImperialCourtContribution = (byte)ReadIntegerData("Daimyoke.ImperialCourtContribution", i);
                daimyoke.DaihoshinTarget = (ushort)ReadIntegerData("Daimyoke.DaihoshinTarget", i);
                daimyoke.SenryakuTarget = (ushort)ReadIntegerData("Daimyoke.SenryakuTarget", i);
                daimyoke.GoyoShonin1 = (byte)ReadIntegerData("Daimyoke.GoyoShonin1", i);
                daimyoke.GoyoShonin2 = (byte)ReadIntegerData("Daimyoke.GoyoShonin2", i);
                daimyoke.GoyoShonin3 = (byte)ReadIntegerData("Daimyoke.GoyoShonin3", i);
                daimyoke.GoyoShoninContribution1 = (byte)ReadIntegerData("Daimyoke.GoyoShoninContribution1", i);
                daimyoke.GoyoShoninContribution2 = (byte)ReadIntegerData("Daimyoke.GoyoShoninContribution2", i);
                daimyoke.GoyoShoninContribution3 = (byte)ReadIntegerData("Daimyoke.GoyoShoninContribution3", i);
                // 管理用
                daimyoke.ID = i;
                daimyoke.IsDestruction = (daimyoke.Leader == GameData.NoneBushoID);
                if (!daimyoke.IsDestruction)
                    daimyoke.Name = bushoList[daimyoke.Leader].FamilyName + @"家";
                // 追加
                seiryokuList.Add(daimyoke);
            }
            // 商家の読み取り
            for (int i = 0; i < GameData.NumOfShoka; ++i)
            {
                // 読み取り
                Shoka shoka = new Shoka();
                shoka.Ceasefire = ReadBytesData("Shoka.Ceasefire", i);
                shoka.JustCause = ReadBytesData("Shoka.JustCause", i);
                shoka.Diplomacy = ReadBytesData("Shoka.Diplomacy", i);
                shoka.DepartureCounter = (byte)ReadIntegerData("Shoka.DepartureCounter", i);
                shoka.RelationshipWithShujinko = (byte)ReadIntegerData("Shoka.RelationshipWithShujinko", i);
                shoka.FamilyCrest = (byte)ReadIntegerData("Shoka.FamilyCrest", i);
                var leader = ReadBytesData("Shoka.StoreLeaders", i);
                var kyoten = ReadBytesData("Shoka.StoreKyotens", i);
                var money = ReadBytesData("Shoka.StoreMoney", i);
                var guns = ReadBytesData("Shoka.StoreGuns", i);
                var advertisement = ReadBytesData("Shoka.StoreAdvertisement", i);
                shoka.SetStoresData(leader, kyoten, money, guns, advertisement);
                shoka.HomeStore = (byte)ReadIntegerData("Shoka.HomeStore", i);
                shoka.NameID = (byte)ReadIntegerData("Shoka.NameID", i);
                // 管理用
                shoka.ID = GameData.NumOfDaimyoke + i;
                shoka.IsDestruction = (shoka.Leader == GameData.NoneBushoID);
                if (!shoka.IsDestruction)
                {
                    if (shoka.NameID == GameData.MyShokaNameID)
                        shoka.Name = shujinko.NameOfMyShoka + @"屋";
                    else if (shoka.NameID != GameData.NoneShokaNameID)
                        shoka.Name = _NameListDictionary["Sho-ka"][shoka.NameID];
                }
                // 追加
                seiryokuList.Add(shoka);
            }
            // 忍者衆の読み取り
            for (int i = 0; i < GameData.NumOfNinjaShu; ++i)
            {
                // 読み取り
                NinjaShu ninjaShu = new NinjaShu();
                ninjaShu.Ceasefire = ReadBytesData("NinjaShu.Ceasefire", i);
                ninjaShu.JustCause = ReadBytesData("NinjaShu.JustCause", i);
                ninjaShu.Diplomacy = ReadBytesData("NinjaShu.Diplomacy", i);
                ninjaShu.DepartureCounter = (byte)ReadIntegerData("NinjaShu.DepartureCounter", i);
                ninjaShu.RelationshipWithShujinko = (byte)ReadIntegerData("NinjaShu.RelationshipWithShujinko", i);
                ninjaShu.FamilyCrest = (byte)ReadIntegerData("NinjaShu.FamilyCrest", i);
                ninjaShu.Leader = (ushort)ReadIntegerData("NinjaShu.Leader", i);
                ninjaShu.NameID = (byte)ReadIntegerData("NinjaShu.NameID", i);
                ninjaShu.Senryaku = (byte)ReadIntegerData("NinjaShu.Senryaku", i);
                ninjaShu.SenryakuTarget = (ushort)ReadIntegerData("NinjaShu.SenryakuTarget", i);
                // 管理用
                ninjaShu.ID = GameData.NumOfDaimyoke + GameData.NumOfShoka + i;
                ninjaShu.IsDestruction = (ninjaShu.Leader == GameData.NoneBushoID);
                if (!ninjaShu.IsDestruction)
                    ninjaShu.Name = _NameListDictionary["Ninja-shu"][ninjaShu.NameID];
                // 追加
                seiryokuList.Add(ninjaShu);
            }
            // 海賊衆の読み取り
            for (int i = 0; i < GameData.NumOfKaizokuShu; ++i)
            {
                // 読み取り
                KaizokuShu kaizokuShu = new KaizokuShu();
                kaizokuShu.Ceasefire = ReadBytesData("KaizokuShu.Ceasefire", i);
                kaizokuShu.JustCause = ReadBytesData("KaizokuShu.JustCause", i);
                kaizokuShu.Diplomacy = ReadBytesData("KaizokuShu.Diplomacy", i);
                kaizokuShu.DepartureCounter = (byte)ReadIntegerData("KaizokuShu.DepartureCounter", i);
                kaizokuShu.RelationshipWithShujinko = (byte)ReadIntegerData("KaizokuShu.RelationshipWithShujinko", i);
                kaizokuShu.FamilyCrest = (byte)ReadIntegerData("KaizokuShu.FamilyCrest", i);
                kaizokuShu.ShipbuildingMiddle = (byte)ReadIntegerData("KaizokuShu.ShipbuildingMiddle", i);
                kaizokuShu.ShipbuildingStrong = (byte)ReadIntegerData("KaizokuShu.ShipbuildingStrong", i);
                kaizokuShu.Leader = (ushort)ReadIntegerData("KaizokuShu.Leader", i);
                kaizokuShu.NameID = (byte)ReadIntegerData("KaizokuShu.NameID", i);
                kaizokuShu.Senryaku = (byte)ReadIntegerData("KaizokuShu.Senryaku", i);
                kaizokuShu.SenryakuTarget = (ushort)ReadIntegerData("KaizokuShu.SenryakuTarget", i);
                // 管理用
                kaizokuShu.ID = GameData.NumOfDaimyoke + GameData.NumOfShoka + GameData.NumOfNinjaShu + i;
                kaizokuShu.IsDestruction = (kaizokuShu.Leader == GameData.NoneBushoID);
                if (!kaizokuShu.IsDestruction)
                    kaizokuShu.Name = _NameListDictionary["Kaizoku-shu"][kaizokuShu.NameID];
                // 追加
                seiryokuList.Add(kaizokuShu);
            }

            return seiryokuList;
        }

        /// <summary>
        /// 勢力データの書き込み
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        private void WriteSeiryokuData(GameData gameData)
        {
            // 勢力リスト
            List<Seiryoku> seiryokuList = gameData.SeiryokuList;

            // 大名家の書き込み
            for (int i = 0; i < GameData.NumOfDaimyoke; ++i)
            {
                Daimyoke daimyoke = (Daimyoke)seiryokuList[i];
                WriteBytesData("Daimyoke.Ceasefire", daimyoke.Ceasefire, i);
                WriteBytesData("Daimyoke.JustCause", daimyoke.JustCause, i);
                WriteBytesData("Daimyoke.Diplomacy", daimyoke.Diplomacy, i);
                WriteIntegerData("Daimyoke.DepartureCounter", daimyoke.DepartureCounter, i);
                WriteIntegerData("Daimyoke.RelationshipWithShujinko", daimyoke.RelationshipWithShujinko, i);
                WriteIntegerData("Daimyoke.FamilyCrest", daimyoke.FamilyCrest, i);
                WriteIntegerData("Daimyoke.InactivationFlag", daimyoke.InactivationFlag, i);
                WriteIntegerData("Daimyoke.Daihoshin", daimyoke.Daihoshin, i);
                WriteIntegerData("Daimyoke.Senryaku", daimyoke.Senryaku, i);
                WriteIntegerData("Daimyoke.Leader", daimyoke.Leader, i);
                WriteIntegerData("Daimyoke.ImperialCourtContribution", daimyoke.ImperialCourtContribution, i);
                WriteIntegerData("Daimyoke.DaihoshinTarget", daimyoke.DaihoshinTarget, i);
                WriteIntegerData("Daimyoke.SenryakuTarget", daimyoke.SenryakuTarget, i);
                WriteIntegerData("Daimyoke.GoyoShonin1", daimyoke.GoyoShonin1, i);
                WriteIntegerData("Daimyoke.GoyoShonin2", daimyoke.GoyoShonin2, i);
                WriteIntegerData("Daimyoke.GoyoShonin3", daimyoke.GoyoShonin3, i);
                WriteIntegerData("Daimyoke.GoyoShoninContribution1", daimyoke.GoyoShoninContribution1, i);
                WriteIntegerData("Daimyoke.GoyoShoninContribution2", daimyoke.GoyoShoninContribution2, i);
                WriteIntegerData("Daimyoke.GoyoShoninContribution3", daimyoke.GoyoShoninContribution3, i);
            }
            // 商家の書き込み
            for (int i = 0; i < GameData.NumOfShoka; ++i)
            {
                int index = GameData.NumOfDaimyoke + i;
                Shoka shoka = (Shoka)seiryokuList[index];
                WriteBytesData("Shoka.Ceasefire", shoka.Ceasefire, i);
                WriteBytesData("Shoka.JustCause", shoka.JustCause, i);
                WriteBytesData("Shoka.Diplomacy", shoka.Diplomacy, i);
                WriteIntegerData("Shoka.DepartureCounter", shoka.DepartureCounter, i);
                WriteIntegerData("Shoka.RelationshipWithShujinko", shoka.RelationshipWithShujinko, i);
                WriteIntegerData("Shoka.FamilyCrest", shoka.FamilyCrest, i);
                WriteBytesData("Shoka.StoreLeaders", shoka.GetStoreLeaderBytes(), i);
                WriteBytesData("Shoka.StoreKyotens", shoka.GetStoreKyotenBytes(), i);
                WriteBytesData("Shoka.StoreMoney", shoka.GetStoreMoneyBytes(), i);
                WriteBytesData("Shoka.StoreGuns", shoka.GetStoreGunsBytes(), i);
                WriteBytesData("Shoka.StoreAdvertisement", shoka.GetStoreAdvertisementBytes(), i);
                WriteIntegerData("Shoka.HomeStore", shoka.HomeStore, i);
                WriteIntegerData("Shoka.NameID", shoka.NameID, i);
            }
            // 忍者衆の書き込み
            for (int i = 0; i < GameData.NumOfNinjaShu; ++i)
            {
                int index = GameData.NumOfDaimyoke + GameData.NumOfShoka + i;
                NinjaShu ninjaShu = (NinjaShu)seiryokuList[index];
                WriteBytesData("NinjaShu.Ceasefire", ninjaShu.Ceasefire, i);
                WriteBytesData("NinjaShu.JustCause", ninjaShu.JustCause, i);
                WriteBytesData("NinjaShu.Diplomacy", ninjaShu.Diplomacy, i);
                WriteIntegerData("NinjaShu.DepartureCounter", ninjaShu.DepartureCounter, i);
                WriteIntegerData("NinjaShu.RelationshipWithShujinko", ninjaShu.RelationshipWithShujinko, i);
                WriteIntegerData("NinjaShu.FamilyCrest", ninjaShu.FamilyCrest, i);
                WriteIntegerData("NinjaShu.Leader", ninjaShu.Leader, i);
                WriteIntegerData("NinjaShu.NameID", ninjaShu.NameID, i);
                WriteIntegerData("NinjaShu.Senryaku", ninjaShu.Senryaku, i);
                WriteIntegerData("NinjaShu.SenryakuTarget", ninjaShu.SenryakuTarget, i);
            }
            // 海賊衆の書き込み
            for (int i = 0; i < GameData.NumOfKaizokuShu; ++i)
            {
                int index = GameData.NumOfDaimyoke + GameData.NumOfShoka + GameData.NumOfNinjaShu + i;
                KaizokuShu kaizokuShu = (KaizokuShu)seiryokuList[index];
                WriteBytesData("KaizokuShu.Ceasefire", kaizokuShu.Ceasefire, i);
                WriteBytesData("KaizokuShu.JustCause", kaizokuShu.JustCause, i);
                WriteBytesData("KaizokuShu.Diplomacy", kaizokuShu.Diplomacy, i);
                WriteIntegerData("KaizokuShu.DepartureCounter", kaizokuShu.DepartureCounter, i);
                WriteIntegerData("KaizokuShu.RelationshipWithShujinko", kaizokuShu.RelationshipWithShujinko, i);
                WriteIntegerData("KaizokuShu.FamilyCrest", kaizokuShu.FamilyCrest, i);
                WriteIntegerData("KaizokuShu.ShipbuildingMiddle", kaizokuShu.ShipbuildingMiddle, i);
                WriteIntegerData("KaizokuShu.ShipbuildingStrong", kaizokuShu.ShipbuildingStrong, i);
                WriteIntegerData("KaizokuShu.Leader", kaizokuShu.Leader, i);
                WriteIntegerData("KaizokuShu.NameID", kaizokuShu.NameID, i);
                WriteIntegerData("KaizokuShu.Senryaku", kaizokuShu.Senryaku, i);
                WriteIntegerData("KaizokuShu.SenryakuTarget", kaizokuShu.SenryakuTarget, i);
            }
        }

        /// <summary>
        /// 拠点データの読み取り
        /// </summary>
        /// <returns>拠点データ</returns>
        private List<Kyoten> ReadKyotenData()
        {
            // 結果として返す拠点リスト
            List<Kyoten> kyotenList = new List<Kyoten>();

            // 城の読み取り
            for (int i = 0; i < GameData.NumOfShiro; ++i)
            {
                // 読み取り
                Shiro shiro = new Shiro();
                shiro.Location = (byte)ReadIntegerData("Shiro.Location", i);
                shiro.Scale = (byte)ReadIntegerData("Shiro.Scale", i);
                shiro.NameID = (ushort)ReadIntegerData("Shiro.NameID", i);
                shiro.Leader = (ushort)ReadIntegerData("Shiro.Leader", i);
                shiro.NumOfSoldiers = (ushort)ReadIntegerData("Shiro.NumOfSoldiers", i);
                shiro.MilitaryFood = (uint)ReadIntegerData("Shiro.MilitaryFood", i);
                shiro.Money = (uint)ReadIntegerData("Shiro.Money", i);
                shiro.Morale = (byte)ReadIntegerData("Shiro.Morale", i);
                shiro.DegreeOfTraining = (byte)ReadIntegerData("Shiro.DegreeOfTraining", i);
                shiro.NumOfGuns = (ushort)ReadIntegerData("Shiro.NumOfGuns", i);
                shiro.NumOfWarHorses = (ushort)ReadIntegerData("Shiro.NumOfWarHorses", i);
                shiro.NumOfCannons = (ushort)ReadIntegerData("Shiro.NumOfCannons", i);
                shiro.Kokudaka = (ushort)ReadIntegerData("Shiro.Kokudaka", i);
                shiro.MaxKokudaka = (byte)ReadIntegerData("Shiro.MaxKokudakaMultiple", i);
                shiro.Population = (byte)ReadIntegerData("Shiro.Population", i);
                shiro.Mine = (byte)ReadIntegerData("Shiro.Mine", i);
                shiro.MaxMine = (byte)ReadIntegerData("Shiro.MaxMine", i);
                shiro.DefensePower = (byte)ReadIntegerData("Shiro.DefensePower", i);
                shiro.ResidentSupport = (byte)ReadIntegerData("Shiro.ResidentSupport", i);
                shiro.Image = (byte)ReadIntegerData("Shiro.Image", i);
                // 管理用
                shiro.ID = i;
                shiro.Name = _NameListDictionary["Kyoten"][shiro.NameID]; ;
                // 追加
                kyotenList.Add(shiro);
            }
            // 町の読み取り
            for (int i = 0; i < GameData.NumOfMachi; ++i)
            {
                // 読み取り
                Machi machi = new Machi();
                machi.Location = (byte)ReadIntegerData("Machi.Location", i);
                machi.Scale = (byte)ReadIntegerData("Machi.Scale", i);
                machi.NameID = (ushort)ReadIntegerData("Machi.NameID", i);
                machi.Money = (uint)ReadIntegerData("Machi.Money", i);
                machi.Image = (byte)ReadIntegerData("Machi.Image", i);
                machi.RiceStore = (ushort)ReadIntegerData("Machi.RiceStore", i);
                machi.Stable = (ushort)ReadIntegerData("Machi.Stable", i);
                machi.Bar = (ushort)ReadIntegerData("Machi.Bar", i);
                machi.Inn = (ushort)ReadIntegerData("Machi.Inn", i);
                machi.PrivateHouse = (ushort)ReadIntegerData("Machi.PrivateHouse", i);
                machi.Dojo2 = (ushort)ReadIntegerData("Machi.Dojo2", i);
                machi.DoctorHouse = (ushort)ReadIntegerData("Machi.DoctorHouse", i);
                machi.TeaMasterHouse = (ushort)ReadIntegerData("Machi.TeaMasterHouse", i);
                machi.Temple = (ushort)ReadIntegerData("Machi.Temple", i);
                machi.Blacksmith = (ushort)ReadIntegerData("Machi.Blacksmith", i);
                machi.CraftsmanHouse = (ushort)ReadIntegerData("Machi.CraftsmanHouse", i);
                machi.ForeignTemple = (ushort)ReadIntegerData("Machi.ForeignTemple", i);
                machi.ForeignFirm = (ushort)ReadIntegerData("Machi.ForeignFirm", i);
                machi.AristocraticHouse = (ushort)ReadIntegerData("Machi.AristocraticHouse", i);
                machi.ImperialPalace = (ushort)ReadIntegerData("Machi.ImperialPalace", i);
                machi.Market = (ushort)ReadIntegerData("Machi.Market", i);
                machi.Dojo1 = (ushort)ReadIntegerData("Machi.Dojo1", i);
                machi.TradingPost = (ushort)ReadIntegerData("Machi.TradingPost", i);
                machi.RiceMarketPrice = (byte)ReadIntegerData("Machi.RiceMarketPrice", i);
                machi.RiceInventory = (byte)ReadIntegerData("Machi.RiceInventory", i);
                machi.HorseMarketPrice = (byte)ReadIntegerData("Machi.HorseMarketPrice", i);
                machi.HorseInventory = (byte)ReadIntegerData("Machi.HorseInventory", i);
                machi.TradeGoods = ReadBytesData("Machi.TradeGoods", i);
                machi.TradeGoodsSupplyRate = ReadBytesData("Machi.TradeGoodsSupplyRate", i);
                // 管理用
                machi.ID = GameData.NumOfShiro + i;
                machi.Name = _NameListDictionary["Kyoten"][machi.NameID]; ;
                // 追加
                kyotenList.Add(machi);
            }
            // 忍者里の読み取り
            for (int i = 0; i < GameData.NumOfSato; ++i)
            {
                // 読み取り
                Sato sato = new Sato();
                sato.Location = (byte)ReadIntegerData("Sato.Location", i);
                sato.Scale = (byte)ReadIntegerData("Sato.Scale", i);
                sato.NameID = (ushort)ReadIntegerData("Sato.NameID", i);
                sato.Leader = (ushort)ReadIntegerData("Sato.Leader", i);
                sato.NumOfSoldiers = (ushort)ReadIntegerData("Sato.NumOfSoldiers", i);
                sato.MilitaryFood = (uint)ReadIntegerData("Sato.MilitaryFood", i);
                sato.Money = (uint)ReadIntegerData("Sato.Money", i);
                sato.Morale = (byte)ReadIntegerData("Sato.Morale", i);
                sato.DefensePower = (byte)ReadIntegerData("Sato.DefensePower", i);
                sato.DegreeOfTraining = (byte)ReadIntegerData("Sato.DegreeOfTraining", i);
                // 管理用
                sato.ID = GameData.NumOfShiro + GameData.NumOfMachi + i;
                sato.Name = _NameListDictionary["Kyoten"][sato.NameID]; ;
                // 追加
                kyotenList.Add(sato);
            }
            // 海賊砦の読み取り
            for (int i = 0; i < GameData.NumOfToride; ++i)
            {
                // 読み取り
                Toride toride = new Toride();
                toride.Location = (byte)ReadIntegerData("Toride.Location", i);
                toride.Scale = (byte)ReadIntegerData("Toride.Scale", i);
                toride.NameID = (ushort)ReadIntegerData("Toride.NameID", i);
                toride.Leader = (ushort)ReadIntegerData("Toride.Leader", i);
                toride.NumOfWeakWarships = (ushort)ReadIntegerData("Toride.NumOfWeakWarships", i);
                toride.NumOfMiddleWarships = (ushort)ReadIntegerData("Toride.NumOfMiddleWarships", i);
                toride.NumOfStrongWarships = (ushort)ReadIntegerData("Toride.NumOfStrongWarships", i);
                toride.MilitaryFood = (uint)ReadIntegerData("Toride.MilitaryFood", i);
                toride.Money = (uint)ReadIntegerData("Toride.Money", i);
                toride.Morale = (byte)ReadIntegerData("Toride.Morale", i);
                toride.DefensePower = (byte)ReadIntegerData("Toride.DefensePower", i);
                toride.DegreeOfTraining = (byte)ReadIntegerData("Toride.DegreeOfTraining", i);
                // 管理用
                toride.ID = GameData.NumOfShiro + GameData.NumOfMachi + GameData.NumOfSato + i;
                toride.Name = _NameListDictionary["Kyoten"][toride.NameID]; ;
                // 追加
                kyotenList.Add(toride);
            }

            return kyotenList;
        }

        /// <summary>
        /// 拠点データの書き込み
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        private void WriteKyotenData(GameData gameData)
        {
            // 拠点リスト
            List<Kyoten> kyotenList = gameData.KyotenList;

            // 城の書き込み
            for (int i = 0; i < GameData.NumOfShiro; ++i)
            {
                Shiro shiro = (Shiro)kyotenList[i];
                WriteIntegerData("Shiro.Location", shiro.Location, i);
                WriteIntegerData("Shiro.Scale", shiro.Scale, i);
                WriteIntegerData("Shiro.NameID", shiro.NameID, i);
                WriteIntegerData("Shiro.Leader", shiro.Leader, i);
                WriteIntegerData("Shiro.NumOfSoldiers", shiro.NumOfSoldiers, i);
                WriteIntegerData("Shiro.MilitaryFood", shiro.MilitaryFood, i);
                WriteIntegerData("Shiro.Money", shiro.Money, i);
                WriteIntegerData("Shiro.Morale", shiro.Morale, i);
                WriteIntegerData("Shiro.DegreeOfTraining", shiro.DegreeOfTraining, i);
                WriteIntegerData("Shiro.NumOfGuns", shiro.NumOfGuns, i);
                WriteIntegerData("Shiro.NumOfWarHorses", shiro.NumOfWarHorses, i);
                WriteIntegerData("Shiro.NumOfCannons", shiro.NumOfCannons, i);
                WriteIntegerData("Shiro.Kokudaka", shiro.Kokudaka, i);
                WriteIntegerData("Shiro.MaxKokudakaMultiple", shiro.MaxKokudaka, i);
                WriteIntegerData("Shiro.Population", shiro.Population, i);
                WriteIntegerData("Shiro.Mine", shiro.Mine, i);
                WriteIntegerData("Shiro.MaxMine", shiro.MaxMine, i);
                WriteIntegerData("Shiro.DefensePower", shiro.DefensePower, i);
                WriteIntegerData("Shiro.ResidentSupport", shiro.ResidentSupport, i);
                WriteIntegerData("Shiro.Image", shiro.Image, i);
            }
            // 町の書き込み
            for (int i = 0; i < GameData.NumOfMachi; ++i)
            {
                int index = GameData.NumOfShiro + i;
                Machi machi = (Machi)kyotenList[index];
                WriteIntegerData("Machi.Location", machi.Location, i);
                WriteIntegerData("Machi.Scale", machi.Scale, i);
                WriteIntegerData("Machi.NameID", machi.NameID, i);
                WriteIntegerData("Machi.Money", machi.Money, i);
                WriteIntegerData("Machi.Image", machi.Image, i);
                WriteIntegerData("Machi.RiceStore", machi.RiceStore, i);
                WriteIntegerData("Machi.Stable", machi.Stable, i);
                WriteIntegerData("Machi.Bar", machi.Bar, i);
                WriteIntegerData("Machi.Inn", machi.Inn, i);
                WriteIntegerData("Machi.PrivateHouse", machi.PrivateHouse, i);
                WriteIntegerData("Machi.Dojo2", machi.Dojo2, i);
                WriteIntegerData("Machi.DoctorHouse", machi.DoctorHouse, i);
                WriteIntegerData("Machi.TeaMasterHouse", machi.TeaMasterHouse, i);
                WriteIntegerData("Machi.Temple", machi.Temple, i);
                WriteIntegerData("Machi.Blacksmith", machi.Blacksmith, i);
                WriteIntegerData("Machi.CraftsmanHouse", machi.CraftsmanHouse, i);
                WriteIntegerData("Machi.ForeignTemple", machi.ForeignTemple, i);
                WriteIntegerData("Machi.ForeignFirm", machi.ForeignFirm, i);
                WriteIntegerData("Machi.AristocraticHouse", machi.AristocraticHouse, i);
                WriteIntegerData("Machi.ImperialPalace", machi.ImperialPalace, i);
                WriteIntegerData("Machi.Market", machi.Market, i);
                WriteIntegerData("Machi.Dojo1", machi.Dojo1, i);
                WriteIntegerData("Machi.TradingPost", machi.TradingPost, i);
                WriteIntegerData("Machi.RiceMarketPrice", machi.RiceMarketPrice, i);
                WriteIntegerData("Machi.RiceInventory", machi.RiceInventory, i);
                WriteIntegerData("Machi.HorseMarketPrice", machi.HorseMarketPrice, i);
                WriteIntegerData("Machi.HorseInventory", machi.HorseInventory, i);
                WriteBytesData("Machi.TradeGoods", machi.TradeGoods, i);
                WriteBytesData("Machi.TradeGoodsSupplyRate", machi.TradeGoodsSupplyRate, i);
            }
            // 忍者里の書き込み
            for (int i = 0; i < GameData.NumOfSato; ++i)
            {
                int index = GameData.NumOfShiro + GameData.NumOfMachi + i;
                Sato sato = (Sato)kyotenList[index];
                WriteIntegerData("Sato.Location", sato.Location, i);
                WriteIntegerData("Sato.Scale", sato.Scale, i);
                WriteIntegerData("Sato.NameID", sato.NameID, i);
                WriteIntegerData("Sato.Leader", sato.Leader, i);
                WriteIntegerData("Sato.NumOfSoldiers", sato.NumOfSoldiers, i);
                WriteIntegerData("Sato.MilitaryFood", sato.MilitaryFood, i);
                WriteIntegerData("Sato.Money", sato.Money, i);
                WriteIntegerData("Sato.Morale", sato.Morale, i);
                WriteIntegerData("Sato.DefensePower", sato.DefensePower, i);
                WriteIntegerData("Sato.DegreeOfTraining", sato.DegreeOfTraining, i);
            }
            // 海賊砦の書き込み
            for (int i = 0; i < GameData.NumOfToride; ++i)
            {
                int index = GameData.NumOfShiro + GameData.NumOfMachi + GameData.NumOfSato + i;
                Toride toride = (Toride)kyotenList[index];
                WriteIntegerData("Toride.Location", toride.Location, i);
                WriteIntegerData("Toride.Scale", toride.Scale, i);
                WriteIntegerData("Toride.NameID", toride.NameID, i);
                WriteIntegerData("Toride.Leader", toride.Leader, i);
                WriteIntegerData("Toride.NumOfWeakWarships", toride.NumOfWeakWarships, i);
                WriteIntegerData("Toride.NumOfMiddleWarships", toride.NumOfMiddleWarships, i);
                WriteIntegerData("Toride.NumOfStrongWarships", toride.NumOfStrongWarships, i);
                WriteIntegerData("Toride.MilitaryFood", toride.MilitaryFood, i);
                WriteIntegerData("Toride.Money", toride.Money, i);
                WriteIntegerData("Toride.Morale", toride.Morale, i);
                WriteIntegerData("Toride.DefensePower", toride.DefensePower, i);
                WriteIntegerData("Toride.DegreeOfTraining", toride.DegreeOfTraining, i);
            }
        }

        /// <summary>
        /// アイテムデータの読み取り
        /// </summary>
        /// <returns>アイテムデータ</returns>
        private List<Item> ReadItemData()
        {
            // アイテムリスト
            string text = "";
            using (StreamReader streamReader = new StreamReader(ITEM_DATA_FILE_PATH, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }
            var itemList = JsonSerializer.Deserialize<List<Item>>(text);

            // 既存アイテムのデータを読み込む
            for (int i = 0; i < GameData.NumOfNormalItems; ++i)
            {
                itemList[i].IsCraftItem = false;
                itemList[i].IsCrafted = false;
                itemList[i].Owner = (ushort)ReadIntegerData("Item.Owner", i);
                itemList[i].Number = (byte)ReadIntegerData("Item.Number", i);
                itemList[i].SecretFlag = (byte)ReadIntegerData("Item.SecretFlag", i);
            }

            // 制作アイテムのデータを読み込む
            for (int i = 0; i < GameData.NumOfCraftItems; ++i)
            {
                Item item = new Item();
                item.ID = GameData.NumOfNormalItems + i;
                item.IsCraftItem = true;
                item.Name = ReadStringData("CraftItem.Name", i);
                item.Kana = ReadStringData("CraftItem.Kana", i);
                item.Image = (byte)ReadIntegerData("CraftItem.Image", i);
                item.Price = (ushort)ReadIntegerData("CraftItem.Price", i);
                item.Rarity = (byte)ReadIntegerData("CraftItem.Rarity", i);
                item.ItemType = (byte)ReadIntegerData("CraftItem.ItemType", i);
                item.AbilityScores = (byte)ReadIntegerData("CraftItem.AbilityScores", i);
                item.AbilityType = (byte)ReadIntegerData("CraftItem.AbilityType", i);
                item.Owner = (ushort)ReadIntegerData("CraftItem.Owner", i);
                item.Number = (byte)ReadIntegerData("CraftItem.Number", i);
                item.SecretFlag = (byte)ReadIntegerData("CraftItem.SecretFlag", i);
                if (item.Price == 0xFFFF)
                    item.IsCrafted = false;
                else
                    item.IsCrafted = true;
                itemList.Add(item);
            }

            return itemList;
        }

        /// <summary>
        /// アイテムデータの書き込み
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        private void WriteItemData(GameData gameData)
        {
            // アイテムリスト
            List<Item> itemList = gameData.ItemList;

            // 既存アイテムの書き込み
            for (int i = 0; i < GameData.NumOfNormalItems; ++i)
            {
                Item item = itemList[i];
                WriteIntegerData("Item.Owner", item.Owner, i);
                WriteIntegerData("Item.Number", item.Number, i);
                WriteIntegerData("Item.SecretFlag", item.SecretFlag, i);
            }

            // 制作アイテムの書き込み
            for (int i = 0; i < GameData.NumOfCraftItems; ++i)
            {
                int index = GameData.NumOfNormalItems + i;
                WriteStringData("CraftItem.Name", itemList[index].Name, i);
                WriteStringData("CraftItem.Kana", itemList[index].Kana, i);
                WriteIntegerData("CraftItem.Image", itemList[index].Image, i);
                WriteIntegerData("CraftItem.Price", itemList[index].Price, i);
                WriteIntegerData("CraftItem.Rarity", itemList[index].Rarity, i);
                WriteIntegerData("CraftItem.ItemType", itemList[index].ItemType, i);
                WriteIntegerData("CraftItem.AbilityScores", itemList[index].AbilityScores, i);
                WriteIntegerData("CraftItem.AbilityType", itemList[index].AbilityType, i);
                WriteIntegerData("CraftItem.Owner", itemList[index].Owner, i);
                WriteIntegerData("CraftItem.Number", itemList[index].Number, i);
                WriteIntegerData("CraftItem.SecretFlag", itemList[index].SecretFlag, i);
            }
        }

        /// <summary>
        /// 販路データの読み取り
        /// </summary>
        /// <returns>販路データ</returns>
        private List<Hanro> ReadHanroData()
        {
            // 結果として返す販路リスト
            List<Hanro> hanroList = new List<Hanro>();

            // 販路の読み取り
            for (int i = 0; i < GameData.NumOfHanro; ++i)
            {
                Hanro hanro = new Hanro();
                hanro.Kanjo = (int)ReadIntegerData("Hanro.Kanjo", i);
                hanro.Machi1 = (ushort)ReadIntegerData("Hanro.Machi1", i);
                hanro.Machi2 = (ushort)ReadIntegerData("Hanro.Machi2", i);
                hanro.MaintenanceCosts = (ushort)ReadIntegerData("Hanro.MaintenanceCosts", i);
                hanro.Administrator = (ushort)ReadIntegerData("Hanro.Administrator", i);
                hanro.Type = (byte)ReadIntegerData("Hanro.Type", i);
                hanro.Guard = (byte)ReadIntegerData("Hanro.Guard", i);
                hanro.Stopping = (byte)ReadIntegerData("Hanro.Stopping", i);
                // 管理用
                hanro.ID = i;
                hanroList.Add(hanro);
            }

            return hanroList;
        }

        /// <summary>
        /// 販路データの書き込み
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        private void WriteHanroData(GameData gameData)
        {
            // 販路リスト
            List<Hanro> hanroList = gameData.HanroList;

            // 販路の書き込み
            for (int i = 0; i < GameData.NumOfHanro; ++i)
            {
                Hanro hanro = hanroList[i];
                WriteIntegerData("Hanro.Kanjo", (uint)hanro.Kanjo, i);
                WriteIntegerData("Hanro.Machi1", hanro.Machi1, i);
                WriteIntegerData("Hanro.Machi2", hanro.Machi2, i);
                WriteIntegerData("Hanro.MaintenanceCosts", hanro.MaintenanceCosts, i);
                WriteIntegerData("Hanro.Administrator", hanro.Administrator, i);
                WriteIntegerData("Hanro.Type", hanro.Type, i);
                WriteIntegerData("Hanro.Guard", hanro.Guard, i);
                WriteIntegerData("Hanro.Stopping", hanro.Stopping, i);
            }
        }

        /// <summary>
        /// 商圏データの読み取り
        /// </summary>
        /// <returns>商圏データ</returns>
        private List<Shoken> ReadShokenData()
        {
            // 結果として返す商圏リスト
            List<Shoken> shokenList = new List<Shoken>();

            // 商圏の読み取り
            var nameList = _NameListDictionary["Shoken"];
            for (int i = 0; i < GameData.NumOfShoken; ++i)
            {
                Shoken shoken = new Shoken();
                shoken.Daimyoke = (byte)ReadIntegerData("Shoken.Daimyoke", i);
                shoken.ShoninTukasa = (byte)ReadIntegerData("Shoken.ShoninTukasa", i);
                // 管理用
                shoken.ID = i;
                shoken.Name = nameList[i];
                shokenList.Add(shoken);
            }

            return shokenList;
        }

        /// <summary>
        /// 商圏データの書き込み
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        private void WriteShokenData(GameData gameData)
        {
            // 商圏リスト
            List<Shoken> shokenList = gameData.ShokenList;

            // 商圏の書き込み
            for (int i = 0; i < GameData.NumOfShoken; ++i)
            {
                Shoken shoken = shokenList[i];
                WriteIntegerData("Shoken.Daimyoke", shoken.Daimyoke, i);
                WriteIntegerData("Shoken.ShoninTukasa", shoken.ShoninTukasa, i);
            }
        }

        /// <summary>
        /// 流派データの読み取り
        /// </summary>
        /// <param name="shujinko">主人公流派名を読み込むための主人公データ</param>
        /// <returns>流派データ</returns>
        private List<Ryuha> ReadRyuhaData(Shujinko shujinko)
        {
            // 結果として返す流派リスト
            List<Ryuha> ryuhaList = new List<Ryuha>();

            // 流派の読み取り
            for (int i = 0; i < GameData.NumOfRyuha; ++i)
            {
                Ryuha ryuha = new Ryuha();
                ryuha.Leader = (ushort)ReadIntegerData("Ryuha.Leader", i);
                ryuha.License = (byte)ReadIntegerData("Ryuha.License", i);
                ryuha.NameID = (byte)ReadIntegerData("Ryuha.NameID", i);
                ryuha.DojoYaburi = (byte)ReadIntegerData("Ryuha.DojoYaburi", i);
                // 管理用
                ryuha.ID = i;
                ryuha.IsDestruction = (ryuha.Leader == GameData.NoneBushoID);
                if (!ryuha.IsDestruction)
                {
                    if (ryuha.NameID == GameData.MyRyuhaNameID)
                        ryuha.Name = shujinko.NameOfMyRyuha + @"流";
                    else if (ryuha.NameID != GameData.NoneRyuhaID)
                        ryuha.Name = _NameListDictionary["Ryuha"][ryuha.NameID];
                }
                ryuhaList.Add(ryuha);
            }

            return ryuhaList;
        }

        /// <summary>
        /// 流派データの書き込み
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        private void WriteRyuhaData(GameData gameData)
        {
            // 流派リスト
            List<Ryuha> ryuhaList = gameData.RyuhaList;

            // 流派の書き込み
            for (int i = 0; i < GameData.NumOfRyuha; ++i)
            {
                Ryuha ryuha = ryuhaList[i];
                WriteIntegerData("Ryuha.Leader", ryuha.Leader, i);
                WriteIntegerData("Ryuha.License", ryuha.License, i);
                WriteIntegerData("Ryuha.NameID", ryuha.NameID, i);
                WriteIntegerData("Ryuha.DojoYaburi", ryuha.DojoYaburi, i);
            }
        }

        /// <summary>
        /// 官位データの読み取り
        /// </summary>
        /// <returns>官位データ</returns>
        private List<Kani> ReadKaniData()
        {
            // 結果として返す官位リスト
            List<Kani> kaniList = new List<Kani>();

            // 官位の読み取り
            int n = _NameListDictionary["Kan-i"].Count;
            for (int i = 0; i < n; ++i)
            {
                Kani kani = new Kani();
                kani.InauguratedPerson = (ushort)ReadIntegerData("Kani.InauguratedPerson", i);
                kani.ID = i;
                kaniList.Add(kani);
            }

            return kaniList;
        }

        /// <summary>
        /// 官位データの書き込み
        /// </summary>
        /// <param name="gameData">ゲームデータ</param>
        private void WriteKaniData(GameData gameData)
        {
            // 官位リスト
            List<Kani> kaniList = gameData.KaniList;

            // 官位の書き込み
            int n = kaniList.Count;
            for (int i = 0; i < n; ++i)
            {
                Kani kani = kaniList[i];
                WriteIntegerData("Kani.InauguratedPerson", kani.InauguratedPerson, i);
            }
        }

        #endregion

        #region セーブ読み込み処理関係のメソッド
        /// <summary>
        /// byte型配列データの読み込み
        /// </summary>
        /// <param name="dataName">データ名</param>
        /// <param name="dataIndex">何番目のデータを読むか</param>
        /// <returns>byte型配列データ</returns>
        private byte[] ReadBytesData(string dataName, int dataIndex)
        {
            AddressInfo info = _AddressDictionary[dataName];
            int address = info.AddressInt + (info.OffsetBytesOfNextData * dataIndex);
            byte[] data = ReadDataFromAddress(address, info.NumberOfDataBits, info.LeastSignificantBit);
            _PartOfChecksumBefore += CalcSumOfDataBytes(data, info.LeastSignificantBit);
            return data;
        }

        /// <summary>
        /// 整数データの読み込み
        /// </summary>
        /// <param name="dataName">データ名</param>
        /// <param name="dataIndex">何番目のデータを読むか</param>
        /// <returns>整数データ</returns>
        private ulong ReadIntegerData(string dataName, int dataIndex)
        {
            // データの読み込み
            byte[] bytes = ReadBytesData(dataName, dataIndex);
            // 変換して返す
            ulong result = 0;
            int n = bytes.Length;
            if (n > 8) n = 8;
            for (int i = 0; i < n; ++i)
            {
                result = ((ulong)bytes[i] << (i * 8)) | result;
            }
            return result;
        }

        /// <summary>
        /// 文字列データの読み込み
        /// </summary>
        /// <param name="dataName">データ名</param>
        /// <param name="dataIndex">何番目のデータを読むか</param>
        /// <returns>文字列データ</returns>
        private string ReadStringData(string dataName, int dataIndex)
        {
            // データの読み込み
            byte[] bytes = ReadBytesData(dataName, dataIndex);
            // 変換して返す
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            string result = sjisEnc.GetString(bytes);
            result = result.Split('\0')[0];
            return result;
        }

        /// <summary>
        /// アドレス情報からデータを読み込む
        /// </summary>
        /// <param name="address">アドレス(数値)</param>
        /// <param name="numOfDataBits">データのビット数</param>
        /// <param name="lsb">1バイト目の最小ビットの位置</param>
        /// <returns>読み込んだデータ</returns>
        private byte[] ReadDataFromAddress(int address, int numOfDataBits, int lsb)
        {
            // 十分なサイズのバイト配列を用意
            int numOfBytes = (numOfDataBits / 8) + (((numOfDataBits % 8) > 0) ? 1 : 0);
            byte[] data = new byte[numOfBytes];
            // データを読み込む
            int readBits = 8 - lsb;             // 今読み込むビット数
            int beforeReadBits = 0;             // 前に読み込んだビット数
            int sumReadBits = 0;                // これまでに読んだビット数の合計
            // 読み込み予定のビット数の方が残りビット数より小さければそれに合わせる
            if (readBits > numOfDataBits)
                readBits = numOfDataBits;
            // 全てのビットを読み終えるまでループを続ける
            while (sumReadBits < numOfDataBits)
            {
                // データの読み取り
                int startBit = (byte)((lsb + sumReadBits) % 8);
                byte mask = (byte)(0xFF >> (8 - readBits));
                int addrOffset = (sumReadBits / 8) + (((sumReadBits % 8) >= (8 - lsb)) ? 1 : 0);
                byte dataByte = (byte)((_Bytes[address + addrOffset] >> startBit) & mask);
                int index = sumReadBits / 8;
                data[index] = (byte)(data[index] | (dataByte << (beforeReadBits % 8)));
                // 次回ループのための更新
                beforeReadBits = readBits;
                sumReadBits += readBits;
                if (readBits != 8)
                    readBits = 8 - readBits;
                // 読み込み予定のビット数の方が残りビット数より小さければそれに合わせる
                int restOfBits = numOfDataBits - sumReadBits;
                if (readBits > restOfBits)
                    readBits = restOfBits;
            }
            return data;
        }

        #endregion

        #region セーブ書き込み処理関係のメソッド
        /// <summary>
        /// byte型配列データの書き込み
        /// </summary>
        /// <param name="dataName">データ名</param>
        /// <param name="bytes">byte型配列データ</param>
        /// <param name="dataIndex">何番目のデータを書き込むか</param>
        private void WriteBytesData(string dataName, byte[] bytes, int dataIndex)
        {
            AddressInfo info = _AddressDictionary[dataName];
            _PartOfChecksumAfter += CalcSumOfDataBytes(bytes, info.LeastSignificantBit);
            int address = info.AddressInt + (info.OffsetBytesOfNextData * dataIndex);
            WriteDataFromAddress(address, info.NumberOfDataBits, info.LeastSignificantBit, bytes);
        }

        /// <summary>
        /// 整数データの書き込み
        /// </summary>
        /// <param name="dataName">データ名</param>
        /// <param name="integer">整数データ</param>
        /// <param name="dataIndex">何番目のデータを書き込むか</param>
        private void WriteIntegerData(string dataName, ulong integer, int dataIndex)
        {
            // 整数データの変換
            int n = 8;
            byte[] data = new byte[n];
            for (int i = 0; i < n; ++i)
            {
                data[i] = (byte)((integer >> (i * 8)) & 0xFF);
            }
            // 書き込み
            WriteBytesData(dataName, data, dataIndex);
        }

        /// <summary>
        /// 文字列データの書き込み
        /// </summary>
        /// <param name="dataName">データ名</param>
        /// <param name="str">文字列データ</param>
        /// <param name="dataIndex">何番目のデータを書き込むか</param>
        private void WriteStringData(string dataName, string str, int dataIndex)
        {
            // 文字列データの変換
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            byte[] data = sjisEnc.GetBytes(str);
            // データのサイズが足りない可能性もあるので拡張しておく
            AddressInfo info = _AddressDictionary[dataName];
            byte[] dataex = new byte[info.NumberOfDataBits / 8];
            for (int i = 0; i < dataex.Length; ++i)
            {
                if (i < data.Length) dataex[i] = data[i];
                else dataex[i] = 0;
            }
            // 書き込み
            WriteBytesData(dataName, dataex, dataIndex);
        }

        /// <summary>
        /// アドレス情報からデータを書き込む
        /// </summary>
        /// <param name="address">アドレス(数値)</param>
        /// <param name="numOfDataBits">データのビット数</param>
        /// <param name="lsb">1バイト目の最小ビットの位置</param>
        /// <param name="data">書き込むデータ</param>
        private void WriteDataFromAddress(int address, int numOfDataBits, int lsb, byte[] data)
        {
            // データを書き込む
            int writeBits = 8 - lsb;        // 今書き込むビット数
            int beforeWriteBits = 0;        // 前に書き込んだビット数
            int sumWriteBits = 0;           // これまでに読んだビット数の合計
            // 書き込み予定のビット数の方が残りビット数より小さければそれに合わせる
            if (writeBits > numOfDataBits)
                writeBits = numOfDataBits;
            // 全てのビットを書き込むまでループを続ける
            while (sumWriteBits < numOfDataBits)
            {
                // データ書き込み
                int index = sumWriteBits / 8;
                byte dataByte = (byte)(data[index] >> (beforeWriteBits % 8));
                int startBit = (byte)((lsb + sumWriteBits) % 8);
                byte mask = (byte)(((0xFF >> (8 - writeBits)) << startBit) ^ 0xFF );
                int addrOffset = (sumWriteBits / 8) + (((sumWriteBits % 8) >= (8 - lsb)) ? 1 : 0);
                _Bytes[address + addrOffset] = (byte)((_Bytes[address + addrOffset] & mask) | (dataByte << startBit));
                // 次回ループのための更新
                beforeWriteBits = writeBits;
                sumWriteBits += writeBits;
                if (writeBits != 8)
                    writeBits = 8 - writeBits;
                // 書き込み予定のビット数の方が残りビット数より小さければそれに合わせる
                int restOfBits = numOfDataBits - sumWriteBits;
                if (writeBits > restOfBits)
                    writeBits = restOfBits;
            }
        }

        #endregion

        #region チェックサム用のメソッド
        /// <summary>
        /// バイト配列の合計値を計算して返す
        /// </summary>
        /// <param name="bytes">バイト配列</param>
        /// <param name="lsb">開始ビット</param>
        /// <returns>合計値</returns>
        private int CalcSumOfDataBytes(byte[] bytes, int lsb)
        {
            int result = 0;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte data1 = (byte)(bytes[i] << lsb);
                byte data2 = (byte)(bytes[i] >> (8 - lsb));
                result += (data1 + data2);
            }
            return result;
        }

        #endregion

    }
}
