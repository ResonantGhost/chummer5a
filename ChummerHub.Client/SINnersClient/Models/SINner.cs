﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace SINners.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class SINner
    {
        /// <summary>
        /// Initializes a new instance of the SINner class.
        /// </summary>
        public SINner() { }

        /// <summary>
        /// Initializes a new instance of the SINner class.
        /// </summary>
        public SINner(Guid? id = default(Guid?), string downloadUrl = default(string), DateTime? uploadDateTime = default(DateTime?), DateTime? lastChange = default(DateTime?), string language = default(string), SINnerMetaData siNnerMetaData = default(SINnerMetaData), SINnerExtended myExtendedAttributes = default(SINnerExtended), SINnerGroup myGroup = default(SINnerGroup), string alias = default(string))
        {
            Id = id;
            DownloadUrl = downloadUrl;
            UploadDateTime = uploadDateTime;
            LastChange = lastChange;
            Language = language;
            SiNnerMetaData = siNnerMetaData;
            MyExtendedAttributes = myExtendedAttributes;
            MyGroup = myGroup;
            Alias = alias;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "downloadUrl")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "uploadDateTime")]
        public DateTime? UploadDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastChange")]
        public DateTime? LastChange { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "siNnerMetaData")]
        public SINnerMetaData SiNnerMetaData { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "myExtendedAttributes")]
        public SINnerExtended MyExtendedAttributes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "myGroup")]
        public SINnerGroup MyGroup { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public string Alias { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Language != null)
            {
                if (this.Language.Length > 6)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Language", 6);
                }
            }
            if (this.MyGroup != null)
            {
                this.MyGroup.Validate();
            }
            if (this.Alias != null)
            {
                if (this.Alias.Length > 64)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Alias", 64);
                }
            }
        }
    }
}
