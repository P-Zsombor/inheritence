using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inheritence
{
    public partial class Form1 : Form
    {
        dbHandler db;
        public Form1()
        {
            InitializeComponent();
            db = new dbHandler();
            db.readAll();
            car onecar = new car();
            onecar.make = "VW";
            onecar.model = "Bogár";
            onecar.color = "piros";
            onecar.year = 1973;
            onecar.hp = 500;
            db.addOne(onecar);
        }
    }
}
