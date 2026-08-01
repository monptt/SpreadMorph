using Godot;
using System;
using System.Collections.Generic;
using Element;

public class FunctionObject : ObjectBase
{
    public override ObjectType Type => ObjectType.Function;

    Function element = new Function();

    Cell Cell => ObjectView.GetCells()[0];

    protected override void InitView()
    {
        SetIsOneObject(true);
        SetElement(new Function());
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
            if (element is Function functionElement)
            {
                SetElement(functionElement);
            }
            else
            {
                SetElement(new Function());
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
        if (result is Function functionElement)
        {
            SetElement(functionElement);
            return true;
        }
        else
        {
            SetElement(new Function());
            return false;
        }
    }

    void SetElement(Function element)
    {
        this.element = element;
        Cell.SetElement(element);
    }
}
