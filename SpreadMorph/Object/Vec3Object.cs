using Godot;
using System;
using System.Collections.Generic;
using Element;

public partial class Vec3Object : ObjectBase
{
    public override ObjectType Type => ObjectType.Vec3;

    Vec3 element = new Vec3(new Integer(0), new Integer(0), new Integer(0));

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
            if (x is Integer numX && y is Integer numY && z is Integer numZ)
            {
                SetElement(new Vec3(numX, numY, numZ));
            }
            else
            {
                SetElement(new Vec3(new Integer(0), new Integer(0), new Integer(0)));
            }
        }
    }
    public override ElementBase GetElement()
    {
        Integer x = ObjectView.GetCells()[0].Element as Integer;
        Integer y = ObjectView.GetCells()[1].Element as Integer;
        Integer z = ObjectView.GetCells()[2].Element as Integer;
        return new Vec3(x, y, z);
    }

    protected override void InitView()
    {

        SetElement(new Vec3(new Integer(0), new Integer(0), new Integer(0)));
        ObjectView.GetCells()[0].SetFormula("0");
        ObjectView.GetCells()[1].SetFormula("0");
        ObjectView.GetCells()[2].SetFormula("0");
    }

    void SetElement(Vec3 element)
    {
        this.element = element;
        ObjectView.GetCells()[0].SetElement(element.X);
        ObjectView.GetCells()[1].SetElement(element.Y);
        ObjectView.GetCells()[2].SetElement(element.Z);
    }

    protected override bool EvaluateFormula(Formula formula)
    {
        ElementBase element = formula.Evaluate();
        if (element is Vec3 vec3Element)
        {
            SetElement(vec3Element);
            return true;
        }
        else
        {
            return false;
        }
    }
}
