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

// [START storage_list_buckets_partial_success]

using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Linq;

public class ListBucketsWithPartialSuccessSample
{
    /// <summary>
    /// List the buckets with partial success.
    /// </summary>
    /// <param name="projectId">The ID of the project to list the buckets.</param>
    /// <param name="returnPartialSuccess">If true, the buckets from both reachable and unreachable locations will be listed. The default is false.</param>
    public (IReadOnlyList<Bucket> Reachable, IReadOnlyList<string> Unreachable) ListBucketsWithPartialSuccess
        (string projectId = "your-project-id", bool returnPartialSuccess = false)
    {
        var storage = StorageClient.Create();
        var pagedResult = storage.ListBuckets(projectId, options: new ListBucketsOptions
        {
            ReturnPartialSuccess = returnPartialSuccess
        });

        var pages = pagedResult.AsRawResponses().ToList();

        // Get all reachable buckets from all pages.
        var reachableBuckets = pages.SelectMany(page => page.Items ?? Enumerable.Empty<Bucket>()).ToList();

        Console.WriteLine("Buckets:");
        foreach (var bucket in reachableBuckets)
        {
            Console.WriteLine(bucket.Name);
        }

        // Get all unreachable buckets from all pages into a single list.
        var unreachableBuckets = pages.SelectMany(page => page.Unreachable ?? Enumerable.Empty<string>()).ToList();

        if (unreachableBuckets.Any())
        {
            Console.WriteLine("Unreachable Buckets:");
            foreach (var bucket in unreachableBuckets)
            {
                Console.WriteLine(bucket);
            }
        }
        return (reachableBuckets, unreachableBuckets);
    }
}
// [END storage_list_buckets_partial_success]
