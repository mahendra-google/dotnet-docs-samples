/**
 * Copyright 2024 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

// [START storagetransfer_quickstart]
using Google.Cloud.StorageTransfer.V1;
using Xunit.Abstractions;

namespace StorageTransfer.Samples
{
    public class QuickstartSample
    {
        private readonly ITestOutputHelper _output;
        public QuickstartSample(ITestOutputHelper output)
        {
            _output = output;
        }   
        public TransferJob Quickstart(
            // Your Google Cloud Project ID
            string projectId = "my-project-id",
            // The GCS bucket to transfer data from
            string sourceBucket = "my-source-bucket",
            // The GCS bucket to transfer data to
            string sinkBucket = "my-sink-bucket")
        {
            TransferJob transferJob = new TransferJob
            {
                ProjectId = projectId,
                TransferSpec = new TransferSpec
                {
                    GcsDataSink = new GcsData { BucketName = sinkBucket },
                    GcsDataSource = new GcsData { BucketName = sourceBucket }
                },
                Status = TransferJob.Types.Status.Enabled
            };

            StorageTransferServiceClient client = StorageTransferServiceClient.Create();
            TransferJob response = client.CreateTransferJob(new CreateTransferJobRequest { TransferJob = transferJob });
            client.RunTransferJob(new RunTransferJobRequest
            {
                JobName = response.Name,
                ProjectId = projectId
            });

            _output.WriteLine($"Created and ran transfer job from {sourceBucket} to {sinkBucket} with name {response.Name}");

            return response;
        }
    }
}
// [END storagetransfer_quickstart]
