using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaOneDll {
    public class TeamSearchName {
        private int _id;
        private string _name;
        private string _color;
        private Byte[] _smallLogo;

        public TeamSearchName(int id, string name, string color, byte[] smallLogo) {
            this.Id = id;
            this.Name = name;
            this.Color = color;
            this.SmallLogo = smallLogo;
        }

        public int Id { get => this._id; set => this._id = value; }
        public string Name { get => this._name; set => this._name = value; }
        public string Color { get => this._color; set => this._color = value; }
        public byte[] SmallLogo { get => this._smallLogo; set => this._smallLogo = value; }
    }
}
