//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

// An System.Collections.ObjectModel.ObservableCollection that raises
// individual item removal notifications on clear and prevents adding duplicates.
public class FixupCollection<T> : ObservableCollection<T>
{
    protected override void ClearItems()
    {
        new List<T>(this).ForEach(t => Remove(t));
    }

    protected override void InsertItem(int index, T item)
    {
        if (!this.Contains(item))
        {
            base.InsertItem(index, item);
        }
    }
}
public partial class Ejerskab
{
    #region Primitive Properties

    public virtual short andele
    {
        get;
        set;
    }

    public virtual int EjerId
    {
        get;
        set;
    }

    public virtual int HesteID
    {
        get;
        set;
    }

    public virtual int Ejer_RytterId
    {
        get { return _ejer_RytterId; }
        set
        {
            if (_ejer_RytterId != value)
            {
                if (Ryttere_Ejer != null && Ryttere_Ejer.RytterId != value)
                {
                    Ryttere_Ejer = null;
                }
                _ejer_RytterId = value;
            }
        }
    }
    private int _ejer_RytterId;

    public virtual int Hest_HesteId
    {
        get { return _hest_HesteId; }
        set
        {
            if (_hest_HesteId != value)
            {
                if (Heste != null && Heste.HesteId != value)
                {
                    Heste = null;
                }
                _hest_HesteId = value;
            }
        }
    }
    private int _hest_HesteId;

    #endregion
    #region Navigation Properties

    public virtual Rytter_Ejer Ryttere_Ejer
    {
        get { return _ryttere_Ejer; }
        set
        {
            if (!ReferenceEquals(_ryttere_Ejer, value))
            {
                var previousValue = _ryttere_Ejer;
                _ryttere_Ejer = value;
                FixupRyttere_Ejer(previousValue);
            }
        }
    }
    private Rytter_Ejer _ryttere_Ejer;

    public virtual Hest Heste
    {
        get { return _heste; }
        set
        {
            if (!ReferenceEquals(_heste, value))
            {
                var previousValue = _heste;
                _heste = value;
                FixupHeste(previousValue);
            }
        }
    }
    private Hest _heste;

    #endregion
    #region Association Fixup

    private void FixupRyttere_Ejer(Rytter_Ejer previousValue)
    {
        if (previousValue != null && previousValue.Ejerskaber.Contains(this))
        {
            previousValue.Ejerskaber.Remove(this);
        }

        if (Ryttere_Ejer != null)
        {
            if (!Ryttere_Ejer.Ejerskaber.Contains(this))
            {
                Ryttere_Ejer.Ejerskaber.Add(this);
            }
            if (Ejer_RytterId != Ryttere_Ejer.RytterId)
            {
                Ejer_RytterId = Ryttere_Ejer.RytterId;
            }
        }
    }

    private void FixupHeste(Hest previousValue)
    {
        if (previousValue != null && previousValue.Ejerskaber.Contains(this))
        {
            previousValue.Ejerskaber.Remove(this);
        }

        if (Heste != null)
        {
            if (!Heste.Ejerskaber.Contains(this))
            {
                Heste.Ejerskaber.Add(this);
            }
            if (Hest_HesteId != Heste.HesteId)
            {
                Hest_HesteId = Heste.HesteId;
            }
        }
    }

    #endregion
}
public partial class Hest
{
    #region Primitive Properties

    public virtual int HesteId
    {
        get;
        set;
    }

    public virtual string Navn
    {
        get;
        set;
    }

    public virtual string F�destald
    {
        get;
        set;
    }

    public virtual System.DateTime F�deDato
    {
        get;
        set;
    }

    public virtual double H�jde
    {
        get;
        set;
    }

    public virtual double V�gt
    {
        get;
        set;
    }

    public virtual bool Hingst
    {
        get;
        set;
    }

    public virtual string BilledeSti
    {
        get;
        set;
    }

    public virtual int For�lder_HesteId
    {
        get { return _for�lder_HesteId; }
        set
        {
            if (_for�lder_HesteId != value)
            {
                if (Heste2 != null && Heste2.HesteId != value)
                {
                    Heste2 = null;
                }
                _for�lder_HesteId = value;
            }
        }
    }
    private int _for�lder_HesteId;

    #endregion
    #region Navigation Properties

    public virtual ICollection<Ejerskab> Ejerskaber
    {
        get
        {
            if (_ejerskaber == null)
            {
                var newCollection = new FixupCollection<Ejerskab>();
                newCollection.CollectionChanged += FixupEjerskaber;
                _ejerskaber = newCollection;
            }
            return _ejerskaber;
        }
        set
        {
            if (!ReferenceEquals(_ejerskaber, value))
            {
                var previousValue = _ejerskaber as FixupCollection<Ejerskab>;
                if (previousValue != null)
                {
                    previousValue.CollectionChanged -= FixupEjerskaber;
                }
                _ejerskaber = value;
                var newValue = value as FixupCollection<Ejerskab>;
                if (newValue != null)
                {
                    newValue.CollectionChanged += FixupEjerskaber;
                }
            }
        }
    }
    private ICollection<Ejerskab> _ejerskaber;

    public virtual ICollection<Hest> Heste1
    {
        get
        {
            if (_heste1 == null)
            {
                var newCollection = new FixupCollection<Hest>();
                newCollection.CollectionChanged += FixupHeste1;
                _heste1 = newCollection;
            }
            return _heste1;
        }
        set
        {
            if (!ReferenceEquals(_heste1, value))
            {
                var previousValue = _heste1 as FixupCollection<Hest>;
                if (previousValue != null)
                {
                    previousValue.CollectionChanged -= FixupHeste1;
                }
                _heste1 = value;
                var newValue = value as FixupCollection<Hest>;
                if (newValue != null)
                {
                    newValue.CollectionChanged += FixupHeste1;
                }
            }
        }
    }
    private ICollection<Hest> _heste1;

    public virtual Hest Heste2
    {
        get { return _heste2; }
        set
        {
            if (!ReferenceEquals(_heste2, value))
            {
                var previousValue = _heste2;
                _heste2 = value;
                FixupHeste2(previousValue);
            }
        }
    }
    private Hest _heste2;

    public virtual ICollection<Rytter> Ryttere
    {
        get
        {
            if (_ryttere == null)
            {
                var newCollection = new FixupCollection<Rytter>();
                newCollection.CollectionChanged += FixupRyttere;
                _ryttere = newCollection;
            }
            return _ryttere;
        }
        set
        {
            if (!ReferenceEquals(_ryttere, value))
            {
                var previousValue = _ryttere as FixupCollection<Rytter>;
                if (previousValue != null)
                {
                    previousValue.CollectionChanged -= FixupRyttere;
                }
                _ryttere = value;
                var newValue = value as FixupCollection<Rytter>;
                if (newValue != null)
                {
                    newValue.CollectionChanged += FixupRyttere;
                }
            }
        }
    }
    private ICollection<Rytter> _ryttere;

    #endregion
    #region Association Fixup

    private void FixupHeste2(Hest previousValue)
    {
        if (previousValue != null && previousValue.Heste1.Contains(this))
        {
            previousValue.Heste1.Remove(this);
        }

        if (Heste2 != null)
        {
            if (!Heste2.Heste1.Contains(this))
            {
                Heste2.Heste1.Add(this);
            }
            if (For�lder_HesteId != Heste2.HesteId)
            {
                For�lder_HesteId = Heste2.HesteId;
            }
        }
    }

    private void FixupEjerskaber(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (Ejerskab item in e.NewItems)
            {
                item.Heste = this;
            }
        }

        if (e.OldItems != null)
        {
            foreach (Ejerskab item in e.OldItems)
            {
                if (ReferenceEquals(item.Heste, this))
                {
                    item.Heste = null;
                }
            }
        }
    }

    private void FixupHeste1(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (Hest item in e.NewItems)
            {
                item.Heste2 = this;
            }
        }

        if (e.OldItems != null)
        {
            foreach (Hest item in e.OldItems)
            {
                if (ReferenceEquals(item.Heste2, this))
                {
                    item.Heste2 = null;
                }
            }
        }
    }

    private void FixupRyttere(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (Rytter item in e.NewItems)
            {
                if (!item.Heste.Contains(this))
                {
                    item.Heste.Add(this);
                }
            }
        }

        if (e.OldItems != null)
        {
            foreach (Rytter item in e.OldItems)
            {
                if (item.Heste.Contains(this))
                {
                    item.Heste.Remove(this);
                }
            }
        }
    }

    #endregion
}
public partial class Rytter
{
    #region Primitive Properties

    public virtual int RytterId
    {
        get;
        set;
    }

    public virtual string Navn
    {
        get;
        set;
    }

    public virtual System.DateTime F�dselsdag
    {
        get;
        set;
    }

    public virtual System.DateTimeOffset RytterAncinitet
    {
        get;
        set;
    }

    public virtual string BilledeSti
    {
        get;
        set;
    }

    #endregion
    #region Navigation Properties

    public virtual Rytter_Ejer Ryttere_Ejer
    {
        get { return _ryttere_Ejer; }
        set
        {
            if (!ReferenceEquals(_ryttere_Ejer, value))
            {
                var previousValue = _ryttere_Ejer;
                _ryttere_Ejer = value;
                FixupRyttere_Ejer(previousValue);
            }
        }
    }
    private Rytter_Ejer _ryttere_Ejer;

    public virtual ICollection<Hest> Heste
    {
        get
        {
            if (_heste == null)
            {
                var newCollection = new FixupCollection<Hest>();
                newCollection.CollectionChanged += FixupHeste;
                _heste = newCollection;
            }
            return _heste;
        }
        set
        {
            if (!ReferenceEquals(_heste, value))
            {
                var previousValue = _heste as FixupCollection<Hest>;
                if (previousValue != null)
                {
                    previousValue.CollectionChanged -= FixupHeste;
                }
                _heste = value;
                var newValue = value as FixupCollection<Hest>;
                if (newValue != null)
                {
                    newValue.CollectionChanged += FixupHeste;
                }
            }
        }
    }
    private ICollection<Hest> _heste;

    #endregion
    #region Association Fixup

    private void FixupRyttere_Ejer(Rytter_Ejer previousValue)
    {
        if (previousValue != null && ReferenceEquals(previousValue.Ryttere, this))
        {
            previousValue.Ryttere = null;
        }

        if (Ryttere_Ejer != null)
        {
            Ryttere_Ejer.Ryttere = this;
        }
    }

    private void FixupHeste(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (Hest item in e.NewItems)
            {
                if (!item.Ryttere.Contains(this))
                {
                    item.Ryttere.Add(this);
                }
            }
        }

        if (e.OldItems != null)
        {
            foreach (Hest item in e.OldItems)
            {
                if (item.Ryttere.Contains(this))
                {
                    item.Ryttere.Remove(this);
                }
            }
        }
    }

    #endregion
}
public partial class Rytter_Ejer
{
    #region Primitive Properties

    public virtual int RytterId
    {
        get { return _rytterId; }
        set
        {
            if (_rytterId != value)
            {
                if (Ryttere != null && Ryttere.RytterId != value)
                {
                    Ryttere = null;
                }
                _rytterId = value;
            }
        }
    }
    private int _rytterId;

    #endregion
    #region Navigation Properties

    public virtual ICollection<Ejerskab> Ejerskaber
    {
        get
        {
            if (_ejerskaber == null)
            {
                var newCollection = new FixupCollection<Ejerskab>();
                newCollection.CollectionChanged += FixupEjerskaber;
                _ejerskaber = newCollection;
            }
            return _ejerskaber;
        }
        set
        {
            if (!ReferenceEquals(_ejerskaber, value))
            {
                var previousValue = _ejerskaber as FixupCollection<Ejerskab>;
                if (previousValue != null)
                {
                    previousValue.CollectionChanged -= FixupEjerskaber;
                }
                _ejerskaber = value;
                var newValue = value as FixupCollection<Ejerskab>;
                if (newValue != null)
                {
                    newValue.CollectionChanged += FixupEjerskaber;
                }
            }
        }
    }
    private ICollection<Ejerskab> _ejerskaber;

    public virtual Rytter Ryttere
    {
        get { return _ryttere; }
        set
        {
            if (!ReferenceEquals(_ryttere, value))
            {
                var previousValue = _ryttere;
                _ryttere = value;
                FixupRyttere(previousValue);
            }
        }
    }
    private Rytter _ryttere;

    #endregion
    #region Association Fixup

    private void FixupRyttere(Rytter previousValue)
    {
        if (previousValue != null && ReferenceEquals(previousValue.Ryttere_Ejer, this))
        {
            previousValue.Ryttere_Ejer = null;
        }

        if (Ryttere != null)
        {
            Ryttere.Ryttere_Ejer = this;
            if (RytterId != Ryttere.RytterId)
            {
                RytterId = Ryttere.RytterId;
            }
        }
    }

    private void FixupEjerskaber(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (Ejerskab item in e.NewItems)
            {
                item.Ryttere_Ejer = this;
            }
        }

        if (e.OldItems != null)
        {
            foreach (Ejerskab item in e.OldItems)
            {
                if (ReferenceEquals(item.Ryttere_Ejer, this))
                {
                    item.Ryttere_Ejer = null;
                }
            }
        }
    }

    #endregion
}
