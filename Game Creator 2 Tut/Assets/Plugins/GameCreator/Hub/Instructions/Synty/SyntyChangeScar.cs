using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
    [Title("Change Scar")]
    [Description("Changes the Scar Color of a given Material")]

    [Image(typeof(IconColor), ColorTheme.Type.Yellow)]

    [Version(0, 0, 1)]

    [Category("Synty/Change Scar Color")]

    [Parameter("Material", "Material to change scar color")]
    [Parameter("Color", "Color target that the Material turns into")]

    [Keywords("Synty", "Material", "Color", "Scar")]
    [Serializable]
    public class SyntyChangeScar : TInstructionRenderer
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField]
        private Material mat;

        private Color defaultColor;

        [SerializeField]
        private PropertyGetColor m_Color;

        public SyntyChangeScar()
        {
            ColorUtility.TryParseHtmlString("#EDAF97", out defaultColor);
            m_Color = new PropertyGetColor(defaultColor);
        }

        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Change Scar Color of {this.mat} to {this.m_Color}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override async Task Run(Args args)
        {
            if (mat == null) return;

            Color valueTarget = this.m_Color.Get(args);
            int propertyID = Shader.PropertyToID("_Color_Scar");

            mat.SetColor(propertyID, valueTarget);
        }
    }
}
