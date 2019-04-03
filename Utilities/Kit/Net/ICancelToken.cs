using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Betterfly.BetterCode {
	public interface ICancelToken {
		bool IsCancel { get; }
	}
}