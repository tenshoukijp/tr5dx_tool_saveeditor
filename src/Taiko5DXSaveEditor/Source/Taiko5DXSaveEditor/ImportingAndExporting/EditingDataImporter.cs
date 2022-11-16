using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.IO;
using System.Threading.Tasks;
using Taiko5DXSaveEditor.GameObjects;
using Taiko5DXSaveEditor.TableManagement;

namespace Taiko5DXSaveEditor.ImportingAndExporting
{
    /// <summary>
    /// 編集データインポートのクラス
    /// </summary>
    public class EditingDataImporter
    {
        #region フィールド
        /// <summary>
        /// 読み込む編集データ
        /// </summary>
        private List<EditingData> _EditingDataList = new List<EditingData>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 編集データインポートのクラスのコンストラクタ
        /// </summary>
        /// <param name="fileNames">ファイル名</param>
        public EditingDataImporter(string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                string text = "";
                using (StreamReader streamReader = new StreamReader(fileName, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }
                var editingDatas = JsonSerializer.Deserialize<List<EditingData>>(text);
                _EditingDataList.AddRange(editingDatas);
            }
        }

        #endregion

        #region メソッド
        /// <summary>
        /// 適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        public void Apply(GameData gameData)
        {
            foreach (EditingData editingData in _EditingDataList)
            {
                switch (editingData.TableType)
                {
                    case TableType.World:
                        ApplyWorld(gameData, editingData);
                        break;
                    case TableType.Shujinko:
                        ApplyShujinko(gameData, editingData);
                        break;
                    case TableType.Busho:
                    case TableType.GeneralPurpose:
                    case TableType.EventPerson:
                    case TableType.Citizen:
                        ApplyBusho(gameData, editingData);
                        break;
                    case TableType.Daimyoke:
                        ApplyDaimyoke(gameData, editingData);
                        break;
                    case TableType.Shoka:
                        ApplyShoka(gameData, editingData);
                        break;
                    case TableType.NinjaShu:
                        ApplyNinjaShu(gameData, editingData);
                        break;
                    case TableType.KaizokuShu:
                        ApplyKaizokuShu(gameData, editingData);
                        break;
                    case TableType.Shiro:
                        ApplyShiro(gameData, editingData);
                        break;
                    case TableType.Machi:
                        ApplyMachi(gameData, editingData);
                        break;
                    case TableType.Sato:
                        ApplySato(gameData, editingData);
                        break;
                    case TableType.Toride:
                        ApplyToride(gameData, editingData);
                        break;
                    case TableType.NormalItem:
                    case TableType.CraftItem:
                        ApplyItem(gameData, editingData);
                        break;
                    case TableType.Hanro:
                        ApplyHanro(gameData, editingData);
                        break;
                    case TableType.Shoken:
                        ApplyShoken(gameData, editingData);
                        break;
                    case TableType.Ryuha:
                        ApplyRyuha(gameData, editingData);
                        break;
                    case TableType.Kani:
                        ApplyKani(gameData, editingData);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 世界データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyWorld(GameData gameData, EditingData editingData)
        {
            World world = gameData.World;
            World newWorld = JsonSerializer.Deserialize<World>(editingData.Data[0].ToString());
            foreach (var propertyName in editingData.Properties)
            {
                var property = typeof(World).GetProperty(propertyName);
                var newValue = property.GetValue(newWorld);
                property.SetValue(world, newValue);
            }
        }

        /// <summary>
        /// 主人公データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyShujinko(GameData gameData, EditingData editingData)
        {
            Shujinko shujinko = gameData.Shujinko;
            Shujinko newShujinko = JsonSerializer.Deserialize<Shujinko>(editingData.Data[0].ToString());
            foreach (var propertyName in editingData.Properties)
            {
                var property = typeof(Shujinko).GetProperty(propertyName);
                var newValue = property.GetValue(newShujinko);
                property.SetValue(shujinko, newValue);
            }
        }

        /// <summary>
        /// 武将データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyBusho(GameData gameData, EditingData editingData)
        {
            List<Busho> bushoList = gameData.BushoList;
            foreach (var data in editingData.Data)
            {
                Busho newBusho = JsonSerializer.Deserialize<Busho>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newBusho.ID;
                    var property = typeof(Busho).GetProperty(propertyName);
                    var newValue = property.GetValue(newBusho);
                    property.SetValue(bushoList[id], newValue);
                }
            }
        }

        /// <summary>
        /// 大名家データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyDaimyoke(GameData gameData, EditingData editingData)
        {
            List<Seiryoku> seiryokuList = gameData.SeiryokuList;
            foreach (var data in editingData.Data)
            {
                Daimyoke newDaimyoke = JsonSerializer.Deserialize<Daimyoke>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newDaimyoke.ID;
                    Daimyoke daimyoke = (Daimyoke)seiryokuList[id];
                    var property = typeof(Daimyoke).GetProperty(propertyName);
                    var newValue = property.GetValue(newDaimyoke);
                    property.SetValue(daimyoke, newValue);
                    // ツール管理プロパティ用
                    if (propertyName == "Leader")
                    {
                        if (daimyoke.Leader != GameData.NoneBushoID)
                        {
                            daimyoke.IsDestruction = false;
                            daimyoke.Name = gameData.BushoList[daimyoke.Leader].FamilyName + @"家";
                        }
                        else
                        {
                            daimyoke.IsDestruction = true;
                            daimyoke.Name = "";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 商家データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyShoka(GameData gameData, EditingData editingData)
        {
            List<Seiryoku> seiryokuList = gameData.SeiryokuList;
            foreach (var data in editingData.Data)
            {
                Shoka newShoka = JsonSerializer.Deserialize<Shoka>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newShoka.ID;
                    Shoka shoka = (Shoka)seiryokuList[id];
                    string propName = propertyName.Split('.')[0];
                    if (propName == "Store")
                    {
                        string storeProp = propertyName.Split('.')[1];
                        for (int i = 0; i < 15; ++i)
                        {
                            var property = typeof(Store).GetProperty(storeProp);
                            var newValue = property.GetValue(newShoka.StoreList[i]);
                            property.SetValue(shoka.StoreList[i], newValue);
                        }
                        if (storeProp == "Leader")
                        {
                            if (shoka.Leader != GameData.NoneBushoID)
                            {
                                shoka.IsDestruction = false;
                                if (shoka.NameID == GameData.MyShokaNameID)
                                    shoka.Name = gameData.Shujinko.NameOfMyShoka + @"屋";
                                else if (shoka.NameID != GameData.NoneShokaNameID)
                                    shoka.Name = gameData.NameListDictionary["Sho-ka"][shoka.NameID];
                                else
                                    shoka.Name = "";
                            }
                            else
                            {
                                seiryokuList[id].IsDestruction = true;
                                seiryokuList[id].Name = "";
                            }
                        }
                    }
                    else
                    {
                        var property = typeof(Shoka).GetProperty(propName);
                        var newValue = property.GetValue(newShoka);
                        property.SetValue(seiryokuList[id], newValue);
                        // ツール管理プロパティ用
                        if ((propName == "Leader") || (propName == "NameID") || (propName == "HomeStore"))
                        {
                            if (shoka.Leader != GameData.NoneBushoID)
                            {
                                shoka.IsDestruction = false;
                                if (shoka.NameID == GameData.MyShokaNameID)
                                    shoka.Name = gameData.Shujinko.NameOfMyShoka + @"屋";
                                else if (shoka.NameID != GameData.NoneShokaNameID)
                                    shoka.Name = gameData.NameListDictionary["Sho-ka"][shoka.NameID];
                                else
                                    shoka.Name = "";
                            }
                            else
                            {
                                seiryokuList[id].IsDestruction = true;
                                seiryokuList[id].Name = "";
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 忍者衆データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyNinjaShu(GameData gameData, EditingData editingData)
        {
            List<Seiryoku> seiryokuList = gameData.SeiryokuList;
            foreach (var data in editingData.Data)
            {
                NinjaShu newNinjaShu = JsonSerializer.Deserialize<NinjaShu>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newNinjaShu.ID;
                    NinjaShu ninjaShu = (NinjaShu)seiryokuList[id];
                    var property = typeof(NinjaShu).GetProperty(propertyName);
                    var newValue = property.GetValue(newNinjaShu);
                    property.SetValue(ninjaShu, newValue);
                    // ツール管理プロパティ用
                    if ((propertyName == "Leader") || (propertyName == "NameID"))
                    {
                        if (ninjaShu.Leader != GameData.NoneBushoID)
                        {
                            ninjaShu.IsDestruction = false;
                            ninjaShu.Name = gameData.NameListDictionary["Ninja-shu"][ninjaShu.NameID];
                        }
                        else
                        {
                            ninjaShu.IsDestruction = true;
                            ninjaShu.Name = "";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 海賊衆データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyKaizokuShu(GameData gameData, EditingData editingData)
        {
            List<Seiryoku> seiryokuList = gameData.SeiryokuList;
            foreach (var data in editingData.Data)
            {
                KaizokuShu newKaizokuShu = JsonSerializer.Deserialize<KaizokuShu>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newKaizokuShu.ID;
                    KaizokuShu kaizokuShu = (KaizokuShu)seiryokuList[id];
                    var property = typeof(KaizokuShu).GetProperty(propertyName);
                    var newValue = property.GetValue(newKaizokuShu);
                    property.SetValue(kaizokuShu, newValue);
                    // ツール管理プロパティ用
                    if ((propertyName == "Leader") || (propertyName == "NameID"))
                    {
                        if (kaizokuShu.Leader != GameData.NoneBushoID)
                        {
                            kaizokuShu.IsDestruction = false;
                            kaizokuShu.Name = gameData.NameListDictionary["Kaizoku-shu"][kaizokuShu.NameID];
                        }
                        else
                        {
                            kaizokuShu.IsDestruction = true;
                            kaizokuShu.Name = "";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 城データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyShiro(GameData gameData, EditingData editingData)
        {
            List<Kyoten> kyotenList = gameData.KyotenList;
            foreach (var data in editingData.Data)
            {
                Shiro newShiro = JsonSerializer.Deserialize<Shiro>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newShiro.ID;
                    Shiro shiro = (Shiro)kyotenList[id];
                    var property = typeof(Shiro).GetProperty(propertyName);
                    var newValue = property.GetValue(newShiro);
                    property.SetValue(shiro, newValue);
                    // ツール管理プロパティ用
                    if (propertyName == "NameID")
                    {
                        shiro.Name = gameData.NameListDictionary["Kyoten"][shiro.NameID];
                    }
                }
            }
        }

        /// <summary>
        /// 町データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyMachi(GameData gameData, EditingData editingData)
        {
            List<Kyoten> kyotenList = gameData.KyotenList;
            foreach (var data in editingData.Data)
            {
                Machi newMachi = JsonSerializer.Deserialize<Machi>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newMachi.ID;
                    Machi machi = (Machi)kyotenList[id];
                    var property = typeof(Machi).GetProperty(propertyName);
                    var newValue = property.GetValue(newMachi);
                    property.SetValue(machi, newValue);
                    // ツール管理プロパティ用
                    if (propertyName == "NameID")
                    {
                        machi.Name = gameData.NameListDictionary["Kyoten"][machi.NameID];
                    }
                }
            }
        }

        /// <summary>
        /// 里データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplySato(GameData gameData, EditingData editingData)
        {
            List<Kyoten> kyotenList = gameData.KyotenList;
            foreach (var data in editingData.Data)
            {
                Sato newSato = JsonSerializer.Deserialize<Sato>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newSato.ID;
                    Sato sato = (Sato)kyotenList[id];
                    var property = typeof(Sato).GetProperty(propertyName);
                    var newValue = property.GetValue(newSato);
                    property.SetValue(sato, newValue);
                    // ツール管理プロパティ用
                    if (propertyName == "NameID")
                    {
                        sato.Name = gameData.NameListDictionary["Kyoten"][sato.NameID];
                    }
                }
            }
        }

        /// <summary>
        /// 砦データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyToride(GameData gameData, EditingData editingData)
        {
            List<Kyoten> kyotenList = gameData.KyotenList;
            foreach (var data in editingData.Data)
            {
                Toride newToride = JsonSerializer.Deserialize<Toride>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newToride.ID;
                    Toride toride = (Toride)kyotenList[id];
                    var property = typeof(Toride).GetProperty(propertyName);
                    var newValue = property.GetValue(newToride);
                    property.SetValue(toride, newValue);
                    // ツール管理プロパティ用
                    if (propertyName == "NameID")
                    {
                        toride.Name = gameData.NameListDictionary["Kyoten"][toride.NameID];
                    }
                }
            }
        }

        /// <summary>
        /// アイテムデータの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyItem(GameData gameData, EditingData editingData)
        {
            List<Item> itemList = gameData.ItemList;
            foreach (var data in editingData.Data)
            {
                Item newItem = JsonSerializer.Deserialize<Item>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newItem.ID;
                    Item item = itemList[id];
                    var property = typeof(Item).GetProperty(propertyName);
                    var newValue = property.GetValue(newItem);
                    property.SetValue(item, newValue);
                    // ツール管理プロパティ用
                    if (propertyName == "Price")
                    {
                        if (item.Price != 0xFFFF)
                            item.IsCrafted = true;
                        else
                            item.IsCrafted = false;
                    }
                }
            }
        }

        /// <summary>
        /// 販路データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyHanro(GameData gameData, EditingData editingData)
        {
            List<Hanro> hanroList = gameData.HanroList;
            foreach (var data in editingData.Data)
            {
                Hanro newHanro = JsonSerializer.Deserialize<Hanro>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newHanro.ID;
                    Hanro hanro = hanroList[id];
                    var property = typeof(Hanro).GetProperty(propertyName);
                    var newValue = property.GetValue(newHanro);
                    property.SetValue(hanro, newValue);
                }
            }
        }

        /// <summary>
        /// 商圏データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyShoken(GameData gameData, EditingData editingData)
        {
            List<Shoken> shokenList = gameData.ShokenList;
            foreach (var data in editingData.Data)
            {
                Shoken newShoken = JsonSerializer.Deserialize<Shoken>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newShoken.ID;
                    Shoken shoken = shokenList[id];
                    var property = typeof(Shoken).GetProperty(propertyName);
                    var newValue = property.GetValue(newShoken);
                    property.SetValue(shoken, newValue);
                }
            }
        }

        /// <summary>
        /// 流派データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyRyuha(GameData gameData, EditingData editingData)
        {
            List<Ryuha> ryuhaList = gameData.RyuhaList;
            foreach (var data in editingData.Data)
            {
                Ryuha newRyuha = JsonSerializer.Deserialize<Ryuha>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newRyuha.ID;
                    Ryuha ryuha = ryuhaList[id];
                    var property = typeof(Ryuha).GetProperty(propertyName);
                    var newValue = property.GetValue(newRyuha);
                    property.SetValue(ryuha, newValue);
                    // ツール管理プロパティ用
                    if ((propertyName == "Leader") || (propertyName == "NameID"))
                    {
                        if (ryuha.Leader != GameData.NoneBushoID)
                        {
                            ryuha.IsDestruction = false;
                            if (ryuha.NameID == GameData.MyRyuhaNameID)
                                ryuha.Name = gameData.Shujinko.NameOfMyRyuha + @"流";
                            else if (ryuha.NameID != GameData.NoneRyuhaID)
                                ryuha.Name = gameData.NameListDictionary["Ryuha"][ryuha.NameID];
                            else
                                ryuha.Name = "";
                        }
                        else
                        {
                            ryuha.IsDestruction = true;
                            ryuha.Name = "";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 官位データの適用
        /// </summary>
        /// <param name="gameData">適用対象のゲームデータ</param>
        /// <param name="editingData">読み込んだデータ</param>
        private void ApplyKani(GameData gameData, EditingData editingData)
        {
            List<Kani> kaniList = gameData.KaniList;
            foreach (var data in editingData.Data)
            {
                Kani newKani = JsonSerializer.Deserialize<Kani>(data.ToString());
                foreach (var propertyName in editingData.Properties)
                {
                    int id = newKani.ID;
                    Kani kani = kaniList[id];
                    var property = typeof(Kani).GetProperty(propertyName);
                    var newValue = property.GetValue(newKani);
                    property.SetValue(kani, newValue);
                }
            }
        }

        #endregion

    }
}
