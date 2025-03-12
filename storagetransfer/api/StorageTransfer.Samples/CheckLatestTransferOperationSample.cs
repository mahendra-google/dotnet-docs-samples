// Copyright 2024 Google LLC
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

// [START storagetransfer_get_latest_transfer_operation]

using Google.Cloud.StorageTransfer.V1;
using System;

/// <summary>
/// Checks the latest transfer operation for a given transfer job.
/// </summary>
public class CheckLatestTransferOperationSample
{
    public TransferJob CheckLatestTransferOperation(
             // Your Google Cloud Project ID
             string projectId = "my-project-id",
             // The name of the job to check
             string jobName = "transferJobs/1234567890")
    {
        // Create a Transfer Service client
        StorageTransferServiceClient storageTransfer = StorageTransferServiceClient.Create();
        GetTransferJobRequest getTransferJobRequest = new GetTransferJobRequest { ProjectId = projectId, JobName = jobName };

        // Get Transfer job
        TransferJob transferJob = storageTransfer.GetTransferJob(getTransferJobRequest);
        // Get Latest operation name from transfer job
        string latestOperationName = transferJob.LatestOperationName;

        if (!string.IsNullOrEmpty(latestOperationName))
        {
            Console.WriteLine("The latest operation for transfer job " + jobName + " is: " + latestOperationName + "");
        }
        else
        {
            Console.WriteLine("Transfer job " + jobName + " hasn't run yet, try again after the job has started running.");
        }
        return transferJob;
    }
}
// [END storagetransfer_get_latest_transfer_operation]
