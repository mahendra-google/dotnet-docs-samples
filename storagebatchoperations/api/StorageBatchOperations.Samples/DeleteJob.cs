// Copyright 2025 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License").
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at 
//
// https://www.apache.org/licenses/LICENSE-2.0 
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and 
// limitations under the License.

// [START storage_batch_delete_job]

using Google.Api.Gax;
using Google.Api.Gax.ResourceNames;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using Google.Cloud.StorageBatchOperations.V1;
using Google.LongRunning;
using System;
using System.Collections;
using System.Collections.Generic;

public class DeleteJobSample
{
    /// <summary>Snippet for CreateJob</summary>
    public void DeleteJob(string job = "projects/[PROJECT]/locations/[LOCATION]")
    {
        // Snippet: DeleteJob(DeleteJobRequest, CallSettings)
        // Create client
        StorageBatchOperationsClient storageBatchOperationsClient = StorageBatchOperationsClient.Create();
        // Initialize request argument(s)
        DeleteJobRequest request = new DeleteJobRequest
        {
            JobName = JobName.FromProjectLocationJob("[PROJECT]", "[LOCATION]", "[JOB]"),
            RequestId = "",
        };
        // Make the request
        storageBatchOperationsClient.DeleteJob(request);
        // End snippet
    }
}
// [END storage_batch_delete_job]
