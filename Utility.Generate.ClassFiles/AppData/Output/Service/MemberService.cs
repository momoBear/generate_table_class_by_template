using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Generate.ClassFiles.AppData
{
    public class MemberMyClassService
    {
        public string MemberRepository { get; set; }


        public string GetByIDs(int id)
        {
            return MemberRepository.ToString();
        }


    }
}
