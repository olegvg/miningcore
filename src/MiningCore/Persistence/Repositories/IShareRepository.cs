/*
Copyright 2017 Coin Foundry (coinfoundry.org)
Authors: Oliver Weichhold (oliver@weichhold.com)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
associated documentation files (the "Software"), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial
portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Data;
using MiningCore.Persistence.Model;
using MiningCore.Persistence.Model.Projections;

namespace MiningCore.Persistence.Repositories
{
    public interface IShareRepository
    {
        void Insert(IDbConnection con, IDbTransaction tx, Share share);
        Share[] ReadSharesBeforeCreated(IDbConnection con, string projectId, string poolId, DateTime before, bool inclusive, int pageSize);
        Share[] ReadSharesBeforeAndAfterCreated(IDbConnection con, string projectId, string poolId, DateTime before, DateTime after, bool inclusive, int pageSize);
        Share[] PageSharesBetweenCreated(IDbConnection con, string projectId, string poolId, DateTime start, DateTime end, int page, int pageSize);

        long CountSharesBeforeCreated(IDbConnection con, IDbTransaction tx, string projectId, string poolId, DateTime before);
        void DeleteSharesBeforeCreated(IDbConnection con, IDbTransaction tx, string projectId, string poolId, DateTime before);

        long CountSharesBetweenCreated(IDbConnection con, string projectId, string poolId, string miner, DateTime? start, DateTime? end);
        double? GetAccumulatedShareDifficultyBetweenCreated(IDbConnection con, string projectId, string poolId, DateTime start, DateTime end);
        MinerWorkerHashes[] GetAccumulatedShareDifficultyTotal(IDbConnection con, string projectId, string poolId);
        MinerWorkerHashes[] GetHashAccumulationBetweenCreated(IDbConnection con, string projectId, string poolId, DateTime start, DateTime end);
        MinerWorkerHashes[] GetAllProjectsHashAccumulationBetweenCreated(IDbConnection con, string poolId, DateTime start, DateTime end);
    }
}
