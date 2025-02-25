using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
    [Title("Change Body Art")]
    [Description("Changes the Body Art Color of a given Material")]

    [Image(typeof(IconColor), ColorTheme.Type.Yellow)]

    [Version(0, 0, 1)]

    [Category("Synty/Change Body Art Color")]

    [Parameter("Material", "Material to change body art color")]
    [Parameter("Color", "Color target that the Material turns into")]

    [Keywords("Synty", "Material", "Color", "Body Art")]
    [Serializable]
    public class SyntyChangeBodyArt : TInstructionRenderer
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField]
        private Material mat;

        private Color defaultColor;

        [SerializeField]
        private PropertyGetColor m_Color;

        public SyntyChangeBodyArt()
        {
            ColorUtility.TryParseHtmlString("#3A94C1", out defaultColor);
            m_Color = new PropertyGetColor(defaultColor);
        }

        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Change Body Art Color of {this.mat} to {this.m_Color}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override async Task Run(Args args)
        {
            if (mat == null) return;

            Color valueTarget = this.m_Color.Get(args);
            int propertyID = Shader.PropertyToID("_Color_BodyArt");

            mat.SetColor(propertyID, valueTarget);
        }
    }
}
