using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Utility.Generate.ClassFiles
{
    class Program
    {

        public const string KEYWORD_TABLE_NAME = "__FILE_PREFIX__";

        public static string ROOT_PATH = "";

        /// <summary>
        /// 指定要產生哪些資料表的模型
        /// </summary>
        public static List<string> ALL_TABLE_NAMES = new List<string>
        {
            "Member",
            "Player",
            "User",
        };


        static void Main(string[] args)
        {
            ReadRootPath();

            //防呆處理 跳過空字串的
            ALL_TABLE_NAMES = ALL_TABLE_NAMES.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();


            //資料表(TABLE)模式 產生所有tableName的models
            foreach (var tableName in ALL_TABLE_NAMES)
            {
                var replaceKeywords = new Dictionary<string, string>();

                //指定哪些關鍵字要取代
                replaceKeywords.Add(KEYWORD_TABLE_NAME, tableName);

                //請依序在此處指定要讀哪些範本檔
                ReadAndReplace_ThenCreateNewFile(replaceKeywords, "__FILE_PREFIX__Service.cs", "Service");
                ReadAndReplace_ThenCreateNewFile(replaceKeywords, "__FILE_PREFIX__Model.cs", "Models");
            }

            return;
        }


        private static void ReadRootPath()
        {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            ROOT_PATH = path.Split("bin").FirstOrDefault();
        }


        /// <summary>
        /// 讀取檔案、並將關鍵字取代掉、並寫入新的檔案
        /// </summary>
        /// <param name="replaceKeywords"></param>
        /// <param name="targetFileName"></param>
        /// <param name="folderName"></param>
        private static void ReadAndReplace_ThenCreateNewFile(Dictionary<string, string> replaceKeywords, string targetFileName, string newfolderName)
        {
            var templateFileFolder = ROOT_PATH + "AppData\\Template\\";
            var outputFileFolder = ROOT_PATH + "AppData\\Output\\";

            string targetFilePath = templateFileFolder + targetFileName;

            string newFileName = targetFileName;
            string allText = System.IO.File.ReadAllText(targetFilePath);

            foreach (var item in replaceKeywords)
            {
                allText = allText.Replace(item.Key, item.Value);
                newFileName = newFileName.Replace(item.Key, item.Value);
            }

            if (!string.IsNullOrWhiteSpace(newfolderName))
            {
                newfolderName = newfolderName + "\\";
            }

            if (!Directory.Exists(outputFileFolder + newfolderName))
            {
                Directory.CreateDirectory(outputFileFolder + newfolderName);
            }

            string resultFileName = outputFileFolder + newfolderName + newFileName;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(resultFileName))
            {
                file.Write(allText);
            }
        }




    }
}
