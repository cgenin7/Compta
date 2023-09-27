using System;
using System.Collections;
using System.Collections.Generic;
using ComptaDB;
using ComptaCommun;

namespace Comptability
{
	/// <summary>
	/// Summary description for ClassHistory.
	/// </summary>
	public class ClassHistory
	{
		private List<THistoryInfo> m_HistoryInfo;

		private static ClassHistory m_sHistory;

		private ClassHistory()
		{
		}

		public List<THistoryInfo> HistoryInfo
		{
			get { return m_HistoryInfo; }
            set { m_HistoryInfo = value; }
		}

		public static ClassHistory GetHistory()
		{
			if ( m_sHistory == null )
				m_sHistory = new ClassHistory();
			return m_sHistory;
		}
		
		public void LoadHistoryFromDataStorage(int accountId)
		{
            m_HistoryInfo = HistoryInfoData.GetHistoryInfo(accountId);
		}

        public void SaveHistoryInDataStorage(int accountId)
		{
            if ( m_HistoryInfo != null )
                HistoryInfoData.SaveHistoryInfo(m_HistoryInfo, accountId);
		}
	}
}
