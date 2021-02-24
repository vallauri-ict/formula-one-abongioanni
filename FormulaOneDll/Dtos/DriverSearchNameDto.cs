using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class DriverSearchNameDto {
        private int _number;
        private string _fullName;
        private string _teamColor;

        public DriverSearchNameDto(DataRow row) {
            this.Number = row.Field<int>("number");
            this.FullName = row.Field<string>("full_name");
            this.TeamColor = row.Field<string>("color");
        }

        public DriverSearchNameDto(int number, string fullName, string teamColor) {
            this.Number = number;
            this.FullName = fullName;
            this.TeamColor = teamColor;
        }

        public int Number { get => this._number; set => this._number = value; }
        public string FullName { get => this._fullName; set => this._fullName = value; }
        public string TeamColor { get => this._teamColor; set => this._teamColor = value; }
    }
}
