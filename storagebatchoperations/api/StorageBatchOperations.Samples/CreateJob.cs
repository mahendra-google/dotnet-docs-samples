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

// [START storage_batch_create_job]

using Google.Api.Gax;
using Google.Api.Gax.ResourceNames;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using Google.Cloud.StorageBatchOperations.V1;
using Google.LongRunning;
using System;
using System.Collections;
using System.Collections.Generic;

public class CreateJobSample
{
    /// <summary>Snippet for CreateJob</summary>
    public void CreateJob(string ParentAsLocationName = "projects/[PROJECT]/locations/[LOCATION]")
    {
        // Snippet: CreateJob(CreateJobRequest, CallSettings)
        // Create client
        StorageBatchOperationsClient storageBatchOperationsClient = StorageBatchOperationsClient.Create();
        string parent = ParentAsLocationName;
        Job job = new Job();
        string jobId = "job123";
        // Make the request
        Operation<Job, OperationMetadata> response = storageBatchOperationsClient.CreateJob(parent, job, jobId);

        // Poll until the returned long-running operation is complete
        Operation<Job, OperationMetadata> completedResponse = response.PollUntilCompleted();
        // Retrieve the operation result
        Job result = completedResponse.Result;

        // Or get the name of the operation
        string operationName = response.Name;
        // This name can be stored, then the long-running operation retrieved later by name
        Operation<Job, OperationMetadata> retrievedResponse = storageBatchOperationsClient.PollOnceCreateJob(operationName);
        // Check if the retrieved long-running operation has completed
        if (retrievedResponse.IsCompleted)
        {
            // If it has completed, then access the result
            Job retrievedResult = retrievedResponse.Result;
        }
    }
}
// [END storage_batch_create_job]
