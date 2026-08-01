using Godot;
using System;
using System.Collections.Generic;
using Element;

public partial class StringObject : ObjectBase
{
    public override ObjectType Type => ObjectType.String;

    Element.String element = null;

    protected override void InitView()
    {
        SetIsOneObject(true);
        SetElement(new Element.String(""));
        ObjectView.GetCells()[0].SetFormula("");
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
            ElementBase element = ObjectView.GetCells()[0].Formula.Evaluate();
            if (element is Element.String stringElement)
            {
                SetElement(stringElement);
            }
            else
            {
                SetElement(new Element.String(""));
            }
        }
    }

    public override ElementBase GetElement()
    {
        return element;
    }

    protected override bool EvaluateFormula(Formula formula)
    {
        Element.String element = new Element.String(formula.FormulaStr);
        SetElement(element);
        return true;
    }

    void SetElement(Element.String element)
    {
        this.element = element;
        ObjectView.GetCells()[0].SetElement(element);
    }
}
