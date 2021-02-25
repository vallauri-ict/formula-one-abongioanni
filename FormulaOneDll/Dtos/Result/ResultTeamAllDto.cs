using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class ResultTeamAllDto {
        private int _teamId;
        private string _teamName;
        private int _points;

        public ResultTeamAllDto() {
        }

        public ResultTeamAllDto(int teamId, string teamName, int points) {
            TeamId = teamId;
            TeamName = teamName;
            Points = points;
        }

        public int TeamId { get => _teamId; set => _teamId = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public int Points { get => _points; set => _points = value; }
    }
}
