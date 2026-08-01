using Element;


public partial class Mat2Object : ObjectBase
{
    public override ObjectType Type => ObjectType.Mat2;

    Mat2 element = new Mat2();

    protected override void InitView()
    {
        ObjectView.GetCells()[0].SetFormula("0");
        ObjectView.GetCells()[1].SetFormula("0");
        ObjectView.GetCells()[2].SetFormula("0");
        ObjectView.GetCells()[3].SetFormula("0");
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
            if (a is Number numA && b is Number numB && c is Number numC && d is Number numD)
            {
                SetElement(new Mat2(numA, numB, numC, numD));
            }
            else
            {
                SetElement(new Mat2());
            }
        }
    }

    public override ElementBase GetElement()
    {
        Number a = ObjectView.GetCells()[0].Element as Number;
        Number b = ObjectView.GetCells()[1].Element as Number;
        Number c = ObjectView.GetCells()[2].Element as Number;
        Number d = ObjectView.GetCells()[3].Element as Number;
        return new Mat2(a, b, c, d);
    }

    void SetElement(Mat2 element)
    {
        this.element = element;
        ObjectView.GetCells()[0].SetElement(element.Elements[0]);
        ObjectView.GetCells()[1].SetElement(element.Elements[1]);
        ObjectView.GetCells()[2].SetElement(element.Elements[2]);
        ObjectView.GetCells()[3].SetElement(element.Elements[3]);
    }

    protected override bool EvaluateFormula(Formula formula)
    {
        ElementBase result = formula.Evaluate();
        if (result is Mat2 mat2Element)
        {
            SetElement(mat2Element);
            return true;
        }
        else
        {
            SetElement(new Mat2());
        }
        return false;
    }
}
