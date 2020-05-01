using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace sm_coding_challenge.Models
{
    [DataContract]
    public class PlayerModel
    {
        [DataMember(Name = "player_id")]
        [JsonPropertyName("player_id")]
        public string Id { get; set; }

        [DataMember(Name = "entry_id")]
        [JsonPropertyName("entry_id")]
        public string EntryId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "position")]
        public string Position { get; set; }
    }

    public class ReceivingModel : PlayerModel
    {
        [DataMember(Name = "yds")]
        public string Yds { get; set; }

        [DataMember(Name = "tds")]
        public string Tds { get; set; }

        [DataMember(Name = "rec")]
        public string Rec { get; set; }
    }


    public class RushingModel : PlayerModel
    {
        [DataMember(Name = "yds")]
        public string Yds { get; set; }

        [DataMember(Name = "tds")]
        public string Tds { get; set; }

        [DataMember(Name = "att")]
        public string Att { get; set; }
        
        [DataMember(Name = "fum")]
        public string Fum { get; set; }
    }

    public class PassingModel : PlayerModel
    {
        [DataMember(Name = "yds")]
        public string Yds { get; set; }

        [DataMember(Name = "tds")]
        public string Tds { get; set; }

        [DataMember(Name = "att")]
        public string Att { get; set; }

        [DataMember(Name = "cmp")]
        public string Cmp { get; set; }

        [DataMember(Name = "int")]
        public string Int { get; set; }
    }

    public class KickingModel : PlayerModel
    {
        [DataMember(Name = "fld_goals_made")]
        [JsonPropertyName("fld_goals_made")]
        public string FldGoalsMade { get; set; }

        [DataMember(Name = "fld_goals_att")]
        [JsonPropertyName("fld_goals_att")]
        public string FldGoalsAtt { get; set; }

        [DataMember(Name = "extra_pt_made")]
        [JsonPropertyName("extra_pt_made")]
        public string ExtraPtMade { get; set; }

        [DataMember(Name = "extra_pt_att")]
        [JsonPropertyName("extra_pt_att")]
        public string ExtraPtAtt { get; set; }
    }


    public class ResponseModel
    {
        public List<ReceivingModel> Receiving { get; set; } = new List<ReceivingModel>();
        public List<RushingModel> Rushing { get; set; } = new List<RushingModel>();
        public List<PassingModel> Passing { get; set; } = new List<PassingModel>();
        public List<KickingModel> Kicking { get; set; } = new List<KickingModel>();

    }
}

