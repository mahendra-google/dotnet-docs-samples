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

// [START storage_batch_list_jobs]

using Google.Api.Gax;
using Google.Cloud.StorageBatchOperations.V1;
using System;
using System.Collections.Generic;

public class ListBatchJobsSample
{
    /// <summary>
    /// List storage batch operation jobs.
    /// </summary>
    /// <param name="parent">The parent of the project in (projects/{project_id}/locations/{location_id}) format.</param>
    /// <param name="filter">The field to filter the result.</param>
    /// <param name="listPageSize">The list of page size.</param>
    /// <param name="pageToken">The list of page token.</param>
    /// <param name="orderBy">The field to sort by.</param>
    public IEnumerable<Job> ListBatchJobs(string parent = "projects/{project_id}/locations/{location_id}",
        string filter = "",
        int listPageSize = 100,
        string pageToken = "",
        string orderBy = "")
    {
        StorageBatchOperationsClient storageBatchOperationsClient = StorageBatchOperationsClient.Create();

        ListJobsRequest request = new ListJobsRequest
        {
            Parent = parent,
            Filter = filter,
            PageSize = listPageSize,
            PageToken = pageToken,
            OrderBy = orderBy,
        };
        PagedEnumerable<ListJobsResponse, Job> response = storageBatchOperationsClient.ListJobs(request);
        Console.WriteLine("Storage Batch Operations Jobs are as follows:");
        foreach (Job item in response)
        {
            Console.WriteLine(item.JobName);
        }
        return response;
    }
}
// [END storage_batch_list_jobs]
