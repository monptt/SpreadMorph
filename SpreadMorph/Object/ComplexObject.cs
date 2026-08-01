using Godot;
using System;
using System.Collections.Generic;
using Element;

public partial class ComplexObject : ObjectBase
{
    public override ObjectType Type => ObjectType.Complex;

    Complex element = new Complex(new Integer(0), new Integer(0));

    Cell Cell => ObjectView.GetCells()[0];


    protected override void InitView()
    {
        this.SetIsOneObject(true);
        SetElement(new Complex(new Integer(0), new Integer(0)));
        Cell.SetFormula("0");
        this.SetFormula("0");
    }

    public override void UpdateObject()
    {
        if (IsOneObject)
        {
            ElementBase element = this.Formula.Evaluate();

            if (element is Complex complexElement)
            {
                SetElement(complexElement);
            }
            else
            {
                SetElement(new Complex(new Integer(0), new Integer(0)));
            }
        }
        else
        {
            ElementBase element = Cell.Formula.Evaluate();

            if (element is Complex complexElement)
            {
                SetElement(complexElement);
            }
            else
            {
                SetElement(new Complex(new Integer(0), new Integer(0)));
            }
        }
    }

    protected override bool EvaluateFormula(Formula formula)
    {
        ElementBase result = formula.Evaluate();

        if (result is Complex complexElement)
        {
            SetElement(complexElement);
            return true;
        }
        else
        {
            return false;
        }
    }

    public override ElementBase GetElement()
    {
        return element;
    }

    void SetElement(Complex element)
    {
        this.element = element;
        Cell.SetElement(element);
    }
}
