using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Generate.ClassFiles.AppData
{
    public class UserMyClassService
    {
        public string UserRepository { get; set; }


        public string GetByIDs(int id)
        {
            return UserRepository.ToString();
        }


    }
}
