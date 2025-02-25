using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
    [Title("Change Metal Dark")]
    [Description("Changes the Metal Dark Color of a given Material")]

    [Image(typeof(IconColor), ColorTheme.Type.Yellow)]

    [Version(0, 0, 1)]

    [Category("Synty/Change Metal Dark Color")]

    [Parameter("Material", "Material to change metal dark color")]
    [Parameter("Color", "Color target that the Material turns into")]

    [Keywords("Synty", "Material", "Color", "Metal Dark")]
    [Serializable]
    public class SyntyChangeMetalDark : TInstructionRenderer
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField]
        private Material mat;

        private Color defaultColor;

        [SerializeField]
        private PropertyGetColor m_Color;

        public SyntyChangeMetalDark()
        {
            ColorUtility.TryParseHtmlString("#2D3237", out defaultColor);
            m_Color = new PropertyGetColor(defaultColor);
        }

        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Change Metal Dark Color of {this.mat} to {this.m_Color}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override async Task Run(Args args)
        {
            if (mat == null) return;

            Color valueTarget = this.m_Color.Get(args);
            int propertyID = Shader.PropertyToID("_Color_Metal_Dark");

            mat.SetColor(propertyID, valueTarget);
        }
    }
}
