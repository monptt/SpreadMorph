using Element;

public partial class Mat4Object : ObjectBase
{
    public override ObjectType Type => ObjectType.Mat4;

    Mat4 element = new Mat4();

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
        ObjectView.GetCells()[9].SetFormula("0");
        ObjectView.GetCells()[10].SetFormula("0");
        ObjectView.GetCells()[11].SetFormula("0");
        ObjectView.GetCells()[12].SetFormula("0");
        ObjectView.GetCells()[13].SetFormula("0");
        ObjectView.GetCells()[14].SetFormula("0");
        ObjectView.GetCells()[15].SetFormula("0");
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
            ElementBase j = ObjectView.GetCells()[9].Formula.Evaluate();
            ElementBase k = ObjectView.GetCells()[10].Formula.Evaluate();
            ElementBase l = ObjectView.GetCells()[11].Formula.Evaluate();
            ElementBase m = ObjectView.GetCells()[12].Formula.Evaluate();
            ElementBase n = ObjectView.GetCells()[13].Formula.Evaluate();
            ElementBase o = ObjectView.GetCells()[14].Formula.Evaluate();
            ElementBase p = ObjectView.GetCells()[15].Formula.Evaluate();
            if (a is Integer numA && b is Integer numB && c is Integer numC && d is Integer numD && e is Integer numE && f is Integer numF && g is Integer numG && h is Integer numH && i is Integer numI && j is Integer numJ && k is Integer numK && l is Integer numL && m is Integer numM && n is Integer numN && o is Integer numO && p is Integer numP)
            {
                SetElement(new Mat4(numA, numB, numC, numD, numE, numF, numG, numH, numI, numJ, numK, numL, numM, numN, numO, numP));
            }
            else
            {
                SetElement(new Mat4());
            }
        }
    }

    public override ElementBase GetElement()
    {
        Integer a = ObjectView.GetCells()[0].Element as Integer;
        Integer b = ObjectView.GetCells()[1].Element as Integer;
        Integer c = ObjectView.GetCells()[2].Element as Integer;
        Integer d = ObjectView.GetCells()[3].Element as Integer;
        Integer e = ObjectView.GetCells()[4].Element as Integer;
        Integer f = ObjectView.GetCells()[5].Element as Integer;
        Integer g = ObjectView.GetCells()[6].Element as Integer;
        Integer h = ObjectView.GetCells()[7].Element as Integer;
        Integer i = ObjectView.GetCells()[8].Element as Integer;
        Integer j = ObjectView.GetCells()[9].Element as Integer;
        Integer k = ObjectView.GetCells()[10].Element as Integer;
        Integer l = ObjectView.GetCells()[11].Element as Integer;
        Integer m = ObjectView.GetCells()[12].Element as Integer;
        Integer n = ObjectView.GetCells()[13].Element as Integer;
        Integer o = ObjectView.GetCells()[14].Element as Integer;
        Integer p = ObjectView.GetCells()[15].Element as Integer;
        return new Mat4(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p);
    }

    void SetElement(Mat4 element)
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
        ObjectView.GetCells()[9].SetElement(element.Elements[9]);
        ObjectView.GetCells()[10].SetElement(element.Elements[10]);
        ObjectView.GetCells()[11].SetElement(element.Elements[11]);
        ObjectView.GetCells()[12].SetElement(element.Elements[12]);
        ObjectView.GetCells()[13].SetElement(element.Elements[13]);
        ObjectView.GetCells()[14].SetElement(element.Elements[14]);
        ObjectView.GetCells()[15].SetElement(element.Elements[15]);
    }

    protected override bool EvaluateFormula(Formula formula)
    {
        ElementBase result = formula.Evaluate();
        if (result is Mat4 mat4Element)
        {
            SetElement(mat4Element);
            return true;
        }
        else
        {
            SetElement(new Mat4());
        }
        return false;
    }
}
