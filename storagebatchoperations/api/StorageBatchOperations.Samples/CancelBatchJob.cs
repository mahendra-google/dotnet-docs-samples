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

// [START storage_batch_cancel_job]

using Google.Cloud.StorageBatchOperations.V1;
using System;

public class CancelBatchJobSample
{
    /// <summary>
    /// Cancels a storage batch job.
    /// </summary>
    /// <param name="jobId">The job id of a storage batch job in (projects/{project_id}/locations/{location_id}/jobs/{job_id}) format.</param>
    public CancelJobResponse CancelBatchJob(string jobId = "projects/{project_id}/locations/{location_id}/jobs/{job_id}")
    {
        StorageBatchOperationsClient storageBatchOperationsClient = StorageBatchOperationsClient.Create();
        CancelJobRequest request = new CancelJobRequest
        {
            Name = jobId,
            RequestId = jobId
        };
        CancelJobResponse response = storageBatchOperationsClient.CancelJob(request);
        Console.WriteLine($"The Storage Batch Operations Job (Name:{jobId}) is cancelled ");
        return response;
    }
}
// [END storage_batch_cancel_job]
