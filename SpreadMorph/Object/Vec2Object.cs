using Godot;
using System;
using System.Collections.Generic;
using Element;

public partial class Vec2Object : ObjectBase
{
    public override ObjectType Type => ObjectType.Vec2;

    Vec2 element = new Vec2(new Integer(0), new Integer(0));

    protected override void InitView()
    {
        ObjectView.GetCells()[0].SetFormula("0");
        ObjectView.GetCells()[1].SetFormula("0");
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
            ElementBase x = ObjectView.GetCells()[0].Formula.Evaluate();
            ElementBase y = ObjectView.GetCells()[1].Formula.Evaluate();
            if (x is Integer numX && y is Integer numY)
            {
                SetElement(new Vec2(numX, numY));
            }
            else
            {
                SetElement(new Vec2(new Integer(0), new Integer(0)));
            }
        }
    }

    public override ElementBase GetElement()
    {
        Integer x = ObjectView.GetCells()[0].Element as Integer;
        Integer y = ObjectView.GetCells()[1].Element as Integer;
        return new Vec2(x, y);
    }

    void SetElement(Vec2 element)
    {
        this.element = element;
        ObjectView.GetCells()[0].SetElement(element.X);
        ObjectView.GetCells()[1].SetElement(element.Y);
    }

    protected override bool EvaluateFormula(Formula formula)
    {
        ElementBase result = formula.Evaluate();
        if (result is Vec2 vec2Element)
        {
            SetElement(vec2Element);
            return true;
        }
        else
        {
            return false;
        }
    }
}
