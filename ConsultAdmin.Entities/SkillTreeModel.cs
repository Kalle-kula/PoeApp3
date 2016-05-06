using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class SkillTreeModel : BaseModel
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }

        private bool _isExpanded;
        private bool _isVisble;
        private bool _isArea;
        private bool _isType;
        private bool _isSkill;
        private bool _isTypeClicked;
        private bool _isAreaClicked;
        private bool _areaImgDownClicked;
        private bool _areaImgUpClicked;
        private bool _typeNameImgDown;
        private bool _typeNameImgUp;

        public bool IsAreaClicked
        {
            get { return _isAreaClicked; }
            set
            {
                if (_isAreaClicked != value)
                {
                    SetPropertyField(nameof(IsAreaClicked), ref _isAreaClicked, value);
                }
            }
        }
        public bool IsTypeClicked
        {
            get { return _isTypeClicked; }
            set
            {
                if (_isTypeClicked != value)
                {
                    SetPropertyField(nameof(IsTypeClicked), ref _isTypeClicked, value);
                }
            }
        }
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (_isExpanded != value)
                {
                    SetPropertyField(nameof(IsExpanded), ref _isExpanded, value);
                }
            }
        }
        public bool IsVisible
        {
            get { return _isVisble; }
            set
            {
                if (_isVisble != value)
                {
                    SetPropertyField(nameof(IsVisible), ref _isVisble, value);
                }
            }
        }
        public bool IsSkill
        {
            get { return _isSkill; }
            set
            {
                if (_isSkill != value)
                {
                    SetPropertyField(nameof(IsSkill), ref _isSkill, value);
                }
            }
        }
        public bool IsType
        {
            get { return _isType; }
            set
            {
                if (_isType != value)
                {
                    SetPropertyField(nameof(IsType), ref _isType, value);
                }
            }
        }
        public bool IsArea
        {
            get { return _isArea; }
            set
            {
                if (_isArea != value)
                {
                    SetPropertyField(nameof(IsArea), ref _isArea, value);
                }
            }
        }
        public bool AreaImgDownClicked
        {
            get { return _areaImgDownClicked; }
            set
            {
                if (_areaImgDownClicked != value)
                {
                    SetPropertyField(nameof(AreaImgDownClicked), ref _areaImgDownClicked, value);
                }
            }
        }

        public bool AreaImgUpClicked
        {
            get { return _areaImgUpClicked; }
            set
            {
                if (_areaImgUpClicked != value)
                {
                    SetPropertyField(nameof(AreaImgUpClicked), ref _areaImgUpClicked, value);
                }
            }
        }

        public bool TypeNameImgDown
        {
            get { return _typeNameImgDown; }
            set
            {
                if (_typeNameImgDown != value)
                {
                    SetPropertyField(nameof(TypeNameImgDown), ref _typeNameImgDown, value);
                }
            }
        }

        public bool TypeNameImgUp
        {
            get { return _typeNameImgUp; }
            set
            {
                if (_typeNameImgUp != value)
                {
                    SetPropertyField(nameof(TypeNameImgUp), ref _typeNameImgUp, value);
                }
            }
        }
    }
}
