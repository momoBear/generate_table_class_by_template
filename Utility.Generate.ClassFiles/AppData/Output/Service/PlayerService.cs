using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Generate.ClassFiles.AppData
{
    public class PlayerMyClassService
    {
        public string PlayerRepository { get; set; }


        public string GetByIDs(int id)
        {
            return PlayerRepository.ToString();
        }


    }
}
