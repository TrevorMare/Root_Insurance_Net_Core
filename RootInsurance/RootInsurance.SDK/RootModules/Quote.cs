using System;
using System.Collections.Generic;
using System.Text;

namespace RootInsurance.SDK.RootModules
{

    /// <summary>
    /// Class that implements the quotation Api 
    /// </summary>
    public class Quote
    {

        #region Fields
        private Quotation.Gadget _gadget;
        private Quotation.FuneralCover _funeralCover;
        private Quotation.TermLife _termLife;
        #endregion

        #region Properties
        public Quotation.Gadget Gadget
        {
            get
            {
                if (this._gadget == null)
                    this._gadget = new Quotation.Gadget();
                return this._gadget;
            }
        }
        public Quotation.FuneralCover FuneralCover
        {
            get
            {
                if (this._funeralCover == null)
                    this._funeralCover = new Quotation.FuneralCover();
                return this._funeralCover;
            }
        }
        public Quotation.TermLife TermLife
        {
            get
            {
                if (this._termLife == null)
                    this._termLife = new Quotation.TermLife();
                return this._termLife;
            }
        }
        #endregion

    }
}
