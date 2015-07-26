﻿using System;
using System.Collections.Generic;
using System.Text;

namespace L2PAPIClient.DataModel
{
    #region OAuth-DataTypes

    /// <summary>
    /// The basic response on starting an authorization process (Call to /code )
    /// </summary>
    public class OAuthRequestData
    {
        public string status { get; set; }
        public string device_code { get; set; }
        public int expires_in { get; set; }
        public int interval { get; set; }
        public string verification_url { get; set; }
        public string user_code { get; set; }
    }

    /// <summary>
    /// The response on a authorization token request. (Call to /token )
    /// </summary>
    public class OAuthTokenRequestData
    {
        public string status { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string error { get; set; }
    }

    /// <summary>
    /// The datatype that is send to the Token endpoint for checking authorization status
    /// </summary>
    public class OAuthTokenRequestSendData
    {
        public string client_id { get; set; }
        public string code { get; set; }
        public string grant_type { get; set; }
    }

    /// <summary>
    /// The response to the TokenInfo request (/tokeninfo)
    /// </summary>
    public class OAuthTokenInfo
    {
        public string status { get; set; }
        public string audience { get; set; }
        public string scope { get; set; }
        public int expires_in { get; set; }
        public string state { get; set; }
    }

    #endregion

    #region L2P API-DataTypes (answers)

    /// <summary>
    /// Basic Datatype. Stores the status of the request and eventual Error-Details
    /// </summary>
    public class L2PBaseData
    {
        public string errorDescription;
        public string errorId;
        public bool status;
    }

    /// <summary>
    /// Representation of a Course Room in L2P
    /// 
    /// REMARK: for now, status and courseStatus are disabled because the API will change at that point
    /// </summary>
    public class L2PCourseInfoData : L2PBaseData
    {
        public string uniqueid { get; set; }
        public string semester { get; set; }
        public string courseTitle { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public bool status { get; set; }
        public string courseStatus { get; set; }
        public int itemId { get; set; }
    }

    public class L2PCourseInfoSetData : L2PBaseData
    {
        public List<L2PCourseInfoData> dataset { get; set; }
    }

    /// <summary>
    /// Representation of a Ping
    /// </summary>
    public class L2PPingData : L2PBaseData
    {
        //public bool status { get; set; }
        public string comment { get; set; }
    }

    /// <summary>
    /// Representation of the user Role in a Course room
    /// </summary>
    public class L2PRole : L2PBaseData
    {
        public string role { get; set; }
    }

    /// <summary>
    /// The Response for adding Add-Calls
    /// </summary>
    public class L2PAddUpdateResponse : L2PGenericRequestResponse
    {
        public int itemId;
        public string itemUrl;
        public long modifiedTimestamp;
        public long creationTimestamp;
        public string attachmentFolderPath;
    }

    #endregion


    #region Responses for Requests (not view-Calls)

    /// <summary>
    /// The response for Generic Calls
    /// </summary>
    public class L2PGenericRequestResponse : L2PBaseData
    {
        public string comment;
    }

    public class L2PCreateFolderResponse : L2PGenericRequestResponse
    {
        public string sourceDirectory;
        public int itemId;
        public long modifiedTimestamp;
        public string name;
        public string selfUrl;
    }

    public class L2PSolutionDocument
    {
        public string downloadUrl;
        public int itemId;
        public string fileSize;
        public long modifiedTimestamp;
        public string fileName;
    }

    public class L2PProvideAssignmentSolutionResponse : L2PGenericRequestResponse
    {
        public long creationTimestamp;
        public long modifiedTimestamp;
        public string studentComment;
        public List<L2PSolutionDocument> solutionDocuments;
        public string solutionDirectory;
        public List<String> submittedByStudents;
        public int itemId;
    }





    #endregion

    #region L2P request DataTypes

    public class L2PBaseRequestData
    {
        public override string ToString()
        {
            // If you do not want to use Newtonsoft, create JSON object in a different way
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }

    public class L2PAddAnnouncementRequest : L2PBaseRequestData
    {
        public string body;
        public long expiretime;
        public string title;
    }

    public class L2PAddAssignmentRequest : L2PBaseRequestData
    {
        public long duedate;
        public bool groupsubmissionallowed;
        public double totalmarks;
        public string description;
        public string title;
    }

    public class L2PAddCourseEventRequest : L2PBaseRequestData
    {
        public string category;
        public string description;
        public bool allDay;
        public string location;
        public long endDate;
        public long eventDate;
        public string contentType;
        public string title;
    }

    public class L2PAddDiscussionThreadRequest : L2PBaseRequestData
    {
        public string subject;
        public string body;
    }

    public class L2PAddDiscussionThreadReplyRequest : L2PBaseRequestData
    {
        public string subject;
        public string body;
    }

    public class L2PAddEmailRequest : L2PBaseRequestData
    {
        public string recipients;
        public string cc;
        public string body;
        public string subject;
        public string replyTo;
        //public bool replyTo;
    }

    public class L2PAddHyperlinkRequest : L2PBaseRequestData
    {
        public string url;
        public string notes;
        public string description;
    }

    public class L2PAddWikiRequest : L2PBaseRequestData
    {
        public string title;
        public string body;
    }

    #endregion
}
