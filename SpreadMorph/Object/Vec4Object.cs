using Godot;
using System;
using System.Collections.Generic;
using Element;

public partial class Vec4Object : ObjectBase
{
    public override ObjectType Type => ObjectType.Vec4;

    Vec4 element = new Vec4(new Integer(0), new Integer(0), new Integer(0), new Integer(0));

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
            ElementBase z = ObjectView.GetCells()[2].Formula.Evaluate();
            ElementBase w = ObjectView.GetCells()[3].Formula.Evaluate();
            if (x is Number numX && y is Number numY && z is Number numZ && w is Number numW)
            {
                SetElement(new Vec4(numX, numY, numZ, numW));
            }
            else
            {
                SetElement(new Vec4(new Integer(0), new Integer(0), new Integer(0), new Integer(0)));
            }
        }
    }
    public override ElementBase GetElement()
    {
        Number x = ObjectView.GetCells()[0].Element as Number;
        Number y = ObjectView.GetCells()[1].Element as Number;
        Number z = ObjectView.GetCells()[2].Element as Number;
        Number w = ObjectView.GetCells()[3].Element as Number;
        return new Vec4(x, y, z, w);
    }

    protected override void InitView()
    {

        SetElement(new Vec4(new Integer(0), new Integer(0), new Integer(0), new Integer(0)));
        ObjectView.GetCells()[0].SetFormula("0");
        ObjectView.GetCells()[1].SetFormula("0");
        ObjectView.GetCells()[2].SetFormula("0");
        ObjectView.GetCells()[3].SetFormula("0");
    }

    void SetElement(Vec4 element)
    {
        this.element = element;
        ObjectView.GetCells()[0].SetElement(element.X);
        ObjectView.GetCells()[1].SetElement(element.Y);
        ObjectView.GetCells()[2].SetElement(element.Z);
        ObjectView.GetCells()[3].SetElement(element.W);
    }

    protected override bool EvaluateFormula(Formula formula)
    {
        ElementBase element = formula.Evaluate();
        if (element is Vec4 vec4Element)
        {
            SetElement(vec4Element);
            return true;
        }
        else
        {
            return false;
        }
    }
}
