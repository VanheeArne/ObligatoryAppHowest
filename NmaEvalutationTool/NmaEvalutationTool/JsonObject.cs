using System;
using System.Collections.Generic;
using System.Text;

namespace NmaEvalutationTool
{
    [Serializable]
    class JsonObject
    {
        public string userName { get; set; }
        public string groupName { get; set; }
        public int score1 { get; set; }
        public int score2 { get; set; }
        public int score3 { get; set; }
        public int score4 { get; set; }
        public int score5 { get; set; }
        public string remarks { get; set; }

        public JsonObject(string userName, string groupName, int score1, int score2, int score3, int score4, int score5, string remarks)
        {
            this.userName = userName;
            this.groupName = groupName;
            this.score1 = score1;
            this.score2 = score2;
            this.score3 = score3;
            this.score4 = score4;
            this.score5 = score5;
            this.remarks = remarks;
        }
    }
}
