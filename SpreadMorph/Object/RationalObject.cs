using Godot;
using System;
using System.Collections.Generic;
using Element;

public class RationalObject : ObjectBase
{
    public override ObjectType Type => ObjectType.Rational;

    Rational element = new Rational(new Integer(0), new Integer(1));

    Cell Cell => ObjectView.GetCells()[0];

    protected override void InitView()
    {
        SetIsOneObject(true);
        SetElement(new Rational(new Integer(0), new Integer(1)));
        this.SetFormula("0");
        Cell.SetFormula("0");
    }

    public override void UpdateObject()
    {
        if (IsOneObject)
        {
            bool result = EvaluateFormula(this.Formula);
            this.SetIsError(!result);
        }
        else
        {
            ElementBase element = Cell.Formula.Evaluate();
            if (element is Rational rationalElement)
            {
                SetElement(rationalElement);
            }
            else
            {
                SetElement(new Rational(new Integer(0), new Integer(1)));
            }
        }
    }

    public override ElementBase GetElement()
    {
        return element;
    }

    protected override bool EvaluateFormula(Formula formula)
    {
        ElementBase result = formula.Evaluate();
        if (result is Rational rationalElement)
        {
            SetElement(rationalElement);
            return true;
        }
        else
        {
            SetElement(new Rational(new Integer(0), new Integer(1)));
            return false;
        }
    }

    void SetElement(Rational element)
    {
        this.element = element;
        Cell.SetElement(element);
    }
}
