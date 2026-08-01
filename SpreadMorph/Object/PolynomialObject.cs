using Godot;
using System;
using System.Collections.Generic;
using Element;

public class PolynomialObject : ObjectBase
{
    public override ObjectType Type => ObjectType.Polynomial;

    Polynomial element = new Polynomial();

    Cell Cell => ObjectView.GetCells()[0];

    protected override void InitView()
    {
        SetIsOneObject(true);
        SetElement(new Polynomial());
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
            if (element is Polynomial polynomialElement)
            {
                SetElement(polynomialElement);
            }
            else
            {
                SetElement(new Polynomial());
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
        if (result is Polynomial polynomialElement)
        {
            SetElement(polynomialElement);
            return true;
        }
        else
        {
            SetElement(new Polynomial());
            return false;
        }
    }

    void SetElement(Polynomial element)
    {
        this.element = element;
        Cell.SetElement(element);
    }
}
