using System;
using System.Collections.Generic;
using System.Text;
using CMSExpress.Common.Models;

namespace CMSExpress.AppServices.Models
{
    /// <summary>
    /// 菜单/权限实体.
    /// </summary>
    [Serializable]
    [Table("app_Permissions")]
    public partial class Permission : DbEntity
    {
        #region properties

        private int _id;

        [Column(ColumnType.Primary | ColumnType.AutoIncrement)]
        public int Id
        {
            get { return this._id; }
            set
            {
                this._id = value;
                this.OnPropertyChanged("Id");
            }
        }

        private int _parentId;

        [Column]
        public int ParentId
        {
            get { return this._parentId; }
            set
            {
                this._parentId = value;
                this.OnPropertyChanged("ParentId");
            }
        }

        private string _code;

        [Column]
        public string Code
        {
            get { return this._code; }
            set
            {
                this._code = value;
                this.OnPropertyChanged("Code");
            }
        }

        private string _permissionName;

        [Column]
        public string PermissionName
        {
            get { return this._permissionName; }
            set
            {
                this._permissionName = value;
                this.OnPropertyChanged("PermissionName");
            }
        }

        private string _url;

        [Column]
        public string Url
        {
            get { return this._url; }
            set
            {
                this._url = value;
                this.OnPropertyChanged("Url");
            }
        }

        private string _type;

        [Column]
        public string Type
        {
            get { return this._type; }
            set
            {
                this._type = value;
                this.OnPropertyChanged("Type");
            }
        }

        private bool _isAuthorized;

        [Column]
        public bool IsAuthorized
        {
            get { return this._isAuthorized; }
            set
            {
                this._isAuthorized = value;
                this.OnPropertyChanged("IsAuthorized");
            }
        }

        private int _status;

        /// <summary>
        /// 状态. -1 逻辑删除, 0 隐藏, 1:有效.
        /// </summary>
        [Column]
        public int Status
        {
            get { return this._status; }
            set
            {
                this._status = value;
                this.OnPropertyChanged("Status");
            }
        }

        private int _sortOrder;

        [Column]
        public int SortOrder
        {
            get { return this._sortOrder; }
            set
            {
                this._sortOrder = value;
                this.OnPropertyChanged("SortOrder");
            }
        }

        private string _lastModifier;

        [Column]
        public string LastModifier
        {
            get { return this._lastModifier; }
            set
            {
                this._lastModifier = value;
                this.OnPropertyChanged("LastModifier");
            }
        }

        private DateTime _lastUpdateDate;

        [Column]
        public DateTime LastUpdateDate
        {
            get { return this._lastUpdateDate; }
            set
            {
                this._lastUpdateDate = value;
                this.OnPropertyChanged("LastUpdateDate");
            }
        }
        #endregion
    }
}
