using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utilities
{
    public static class SaveLoad
    {
        public static List<Player> savePlayers = new List<Player>();




        public static void Save(Player player)
        {
            savePlayers.Add(player);
            BinaryFormatter bf = new BinaryFormatter();
            var path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FileStream file = File.Create(path1 + String.Format("\\savedGames.xml"));
            bf.Serialize(file, savePlayers);
            file.Close();

        }

        public static void Delete(Player player)
        {
            savePlayers.Remove(player);
            BinaryFormatter bf = new BinaryFormatter();
            var path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FileStream file = File.Create(path1 + String.Format("\\savedGames.xml"));
            bf.Serialize(file, savePlayers);
            file.Close();

        }
        public static void Load()
        {
            var path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists(path1 + String.Format("\\savedGames.xml")))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(path1 + String.Format("\\savedGames.xml"), FileMode.Open);
                SaveLoad.savePlayers = (List<Player>)bf.Deserialize(file);
                file.Close();
            }
            savePlayers.FirstOrDefault();
        }
    }
}
