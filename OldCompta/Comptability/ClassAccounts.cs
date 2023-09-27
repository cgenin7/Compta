using System;
using System.Collections;
using System.Collections.Generic;
using ComptaDB;
using ComptaCommun;

namespace Comptability
{
	/// <summary>
	/// 
	/// </summary>
	public class ClassAccounts
	{
        private Dictionary<int, TAccountInfo> m_AccountsInfo;

		private static ClassAccounts m_sAccounts;

		private ClassAccounts()
		{
		}

		public Dictionary<int, TAccountInfo> AccountsInfo
		{
			get { return m_AccountsInfo; }
		}

		public static ClassAccounts GetAccounts()
		{
			if ( m_sAccounts == null )
				m_sAccounts = new ClassAccounts();
			return m_sAccounts;
		}

        public string GetAccountNameFromId(int accountId)
        {
            if (m_AccountsInfo != null)
            {
                if (m_AccountsInfo.ContainsKey(accountId))
                {
                    return m_AccountsInfo[accountId].AccountName;
                }
            }
            return "";
        }

        public int GetAccountIdFromName(string accountName)
        {
            if (m_AccountsInfo != null)
            {
                foreach (TAccountInfo info in m_AccountsInfo.Values)
                {
                    if (string.Compare(accountName, info.AccountName) == 0)
                    {
                        return info.AccountId;
                    }
                }
            }
            return -1;
        }

		public void LoadAccountsFromDataStorage()
		{
            m_AccountsInfo = AccountInfoData.GetAccountsInfo();
		}

		public void SaveAccountsInDataStorage(out Exception exception)
		{
            exception = null;
			if ( m_AccountsInfo != null )
                AccountInfoData.SaveAccountsInfo(m_AccountsInfo, out exception);
		}

		public TAccountInfo GetSpecificAccount(int accountId)
        {
            foreach (TAccountInfo account in m_AccountsInfo.Values)
            {
                if (account != null && account.AccountId == accountId)
                    return account;
            }
            return null;
        }

        public List<int> GetRemovedFromSummaryAccounts()
        {
            var res = new List<int>();
            foreach (TAccountInfo account in m_AccountsInfo.Values)
            {
                if (account != null && account.RemoveFromSummary == true)
                    res.Add(account.AccountId);
            }
            return res;
        }

        public int FindNextAccountId()
        {
            int maxNb = 0;
            foreach (int accountId in m_AccountsInfo.Keys)
            {
                if (accountId > maxNb)
                    maxNb = accountId;
            }
            return maxNb + 1;
        }
	}
}
