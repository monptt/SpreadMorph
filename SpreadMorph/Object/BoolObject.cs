using Godot;
using System;
using System.Collections.Generic;
using Element;

public class BoolObject : ObjectBase
{
    public override ObjectType Type => ObjectType.Bool;

    Element.Boolean element = new Element.Boolean(false);

    Cell Cell => ObjectView.GetCells()[0];

    protected override void InitView()
    {
        SetIsOneObject(true);
        SetElement(new Element.Boolean(false));
        this.SetFormula("false");
        Cell.SetFormula("false");
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
            if (element is Element.Boolean boolElement)
            {
                SetElement(boolElement);
            }
            else
            {
                SetElement(new Element.Boolean(false));
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
        if (result is Element.Boolean boolElement)
        {
            SetElement(boolElement);
            return true;
        }
        else
        {
            SetElement(new Element.Boolean(false));
            return false;
        }
    }

    void SetElement(Element.Boolean element)
    {
        this.element = element;
        Cell.SetElement(element);
    }
}
