﻿using UnityEngine;
using System.Collections;

namespace SubHunt
{

		/// <summary>
		/// A record of a change from one state to another
		/// </summary>
		public struct StateChange
		{

				public StateListItem fromState;
				public StateListItem toState;
				public StateList list;
				public bool allowed;

				public  StateChange (StateListItem fromS, StateListItem toS, StateList li, bool a)
				{
						fromState = fromS;
						toState = toS;
						list = li;
						allowed = a;
				}

		}

}