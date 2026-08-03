using Godot;
using System;
using Element;

public partial class Inspector : Node2D
{
    [Export]
    Label selectedPosLabel;

    [Export]
    Label selectedObjTypeLabel;

    [Export]
    Label valueLabel;

    [Export]
    TextureRect previewTextureRect;


    public override void _Ready()
    {
    }

    public void UpdateInspector(GridPos pos, string objType = "null", string value = "null")
    {
        selectedPosLabel.Text = pos.ToString();
        selectedObjTypeLabel.Text = objType;
        valueLabel.Text = value;

        Cell cell = ObjectSpace.Instance.GetCell(pos);
        if (cell != null)
        {
            PreviewElement(cell.Element);
        }
    }

    void PreviewElement(ElementBase element)
    {
        if (element is ILaTeX latex)
        {
            LaTeXture latexTexture = new LaTeXture();
            latexTexture.LatexExpression = latex.ToLaTeX();
            latexTexture.FontSize = 20f;
            latexTexture.AntiAliasing = true;
            latexTexture.Fill = true;
            latexTexture.MathColor = new Color(0, 0, 0, 1);
            latexTexture.ShowError = true;
            previewTextureRect.Texture = latexTexture.Render();
        }
        else
        {
            previewTextureRect.Texture = null;
        }
    }
}
