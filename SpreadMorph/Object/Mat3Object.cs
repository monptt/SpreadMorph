using Element;

public partial class Mat3Object : ObjectBase
{
    public override ObjectType Type => ObjectType.Mat3;

    Mat3 element = new Mat3();

    protected override void InitView()
    {
        ObjectView.GetCells()[0].SetFormula("0");
        ObjectView.GetCells()[1].SetFormula("0");
        ObjectView.GetCells()[2].SetFormula("0");
        ObjectView.GetCells()[3].SetFormula("0");
        ObjectView.GetCells()[4].SetFormula("0");
        ObjectView.GetCells()[5].SetFormula("0");
        ObjectView.GetCells()[6].SetFormula("0");
        ObjectView.GetCells()[7].SetFormula("0");
        ObjectView.GetCells()[8].SetFormula("0");
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
            ElementBase a = ObjectView.GetCells()[0].Formula.Evaluate();
            ElementBase b = ObjectView.GetCells()[1].Formula.Evaluate();
            ElementBase c = ObjectView.GetCells()[2].Formula.Evaluate();
            ElementBase d = ObjectView.GetCells()[3].Formula.Evaluate();
            ElementBase e = ObjectView.GetCells()[4].Formula.Evaluate();
            ElementBase f = ObjectView.GetCells()[5].Formula.Evaluate();
            ElementBase g = ObjectView.GetCells()[6].Formula.Evaluate();
            ElementBase h = ObjectView.GetCells()[7].Formula.Evaluate();
            ElementBase i = ObjectView.GetCells()[8].Formula.Evaluate();
            if (a is Number numA && b is Number numB && c is Number numC && d is Number numD && e is Number numE && f is Number numF && g is Number numG && h is Number numH && i is Number numI)
            {
                SetElement(new Mat3(numA, numB, numC, numD, numE, numF, numG, numH, numI));
            }
            else
            {
                SetElement(new Mat3());
            }
        }
    }

    public override ElementBase GetElement()
    {
        Number a = ObjectView.GetCells()[0].Element as Number;
        Number b = ObjectView.GetCells()[1].Element as Number;
        Number c = ObjectView.GetCells()[2].Element as Number;
        Number d = ObjectView.GetCells()[3].Element as Number;
        Number e = ObjectView.GetCells()[4].Element as Number;
        Number f = ObjectView.GetCells()[5].Element as Number;
        Number g = ObjectView.GetCells()[6].Element as Number;
        Number h = ObjectView.GetCells()[7].Element as Number;
        Number i = ObjectView.GetCells()[8].Element as Number;
        return new Mat3(a, b, c, d, e, f, g, h, i);
    }

    void SetElement(Mat3 element)
    {
        this.element = element;
        ObjectView.GetCells()[0].SetElement(element.Elements[0]);
        ObjectView.GetCells()[1].SetElement(element.Elements[1]);
        ObjectView.GetCells()[2].SetElement(element.Elements[2]);
        ObjectView.GetCells()[3].SetElement(element.Elements[3]);
        ObjectView.GetCells()[4].SetElement(element.Elements[4]);
        ObjectView.GetCells()[5].SetElement(element.Elements[5]);
        ObjectView.GetCells()[6].SetElement(element.Elements[6]);
        ObjectView.GetCells()[7].SetElement(element.Elements[7]);
        ObjectView.GetCells()[8].SetElement(element.Elements[8]);
    }

    protected override bool EvaluateFormula(Formula formula)
    {
        ElementBase result = formula.Evaluate();
        if (result is Mat3 mat3Element)
        {
            SetElement(mat3Element);
            return true;
        }
        else
        {
            SetElement(new Mat3());
        }
        return false;
    }
}
