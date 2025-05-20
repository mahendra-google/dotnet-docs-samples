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

using Google.Api.Gax.ResourceNames;
using Google.Cloud.StorageBatchOperations.V1;
using Google.LongRunning;
using System;

public class CreateBatchJobSample
{
    /// <summary>
    /// Create storage batch operation jobs.
    /// </summary>
    /// <param name="locationName">A resource name with pattern <c>projects/{project}/locations/{location}</c></param
    public Job CreateBatchJob(LocationName locationName, BucketList bucketList, string jobId)
    {
        StorageBatchOperationsClient storageBatchOperationsClient = StorageBatchOperationsClient.Create();
        CreateJobRequest request = new CreateJobRequest
        {
            ParentAsLocationName = locationName,
            JobId = jobId,
            Job = new Job
            {
                DeleteObject = new DeleteObject { PermanentObjectDeletionEnabled = true },
                PutObjectHold =  new PutObjectHold { EventBasedHold = PutObjectHold.Types.HoldStatus.Set},
                BucketList = bucketList,
                
            },
            RequestId = jobId,
        };
       
        Operation<Job, OperationMetadata> response = storageBatchOperationsClient.CreateJob(request);
        Operation<Job, OperationMetadata> completedResponse = response.PollUntilCompleted();

        Job result = completedResponse.Result;
        string operationName = response.Name;
        Operation<Job, OperationMetadata> retrievedResponse = storageBatchOperationsClient.PollOnceCreateJob(operationName);
       
        if (retrievedResponse.IsCompleted)
        {
            Job retrievedResult = retrievedResponse.Result;
            return retrievedResult;
        }
        return result;
    }
}
// [END storage_batch_create_job]
