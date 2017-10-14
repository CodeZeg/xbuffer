using System.Text.RegularExpressions;

/// <summary>
/// 模板处理 简化生成代码的过程
/// </summary>
public class XTemplate
{
    private string mContent;                                        // 当前内容

    private bool mIsLooping;                                        // 处于循环中
    private string mLoopTemplate_Cell;                              // 循环的内容模板
    private string mLoopContent_Cell;                               // 循环的内容（单元）
    private string mLoopContent_All;                                // 循环内容容器（全部）

    private const string LOOPHOLDER = "#TEMP_LOOP_HOLDER#";         // 循环占位符

    public XTemplate(string template)
    {
        mContent = template;
        mIsLooping = false;
        mLoopTemplate_Cell = "";
        mLoopContent_Cell = "";
        mLoopContent_All = "";
    }

    /// <summary>
    /// 返回结果
    /// </summary>
    /// <returns></returns>
    public string getContent()
    {
        return mContent;
    }

    /// <summary>
    /// 设置值
    /// </summary>
    /// <param name="key">需要替换的key</param>
    /// <param name="value">需要赋值的value</param>
    public void setValue(string key, string value)
    {
        if (mIsLooping)
        {
            mLoopContent_Cell = mLoopContent_Cell.Replace(key, value);
        }
        else
        {
            mContent = mContent.Replace(key, value);
        }
    }

    /// <summary>
    /// 设置条件 不满足条件将被剔除
    /// </summary>
    /// <param name="condition">条件key</param>
    /// <param name="value">条件值</param>
    public void setCondition(string condition, bool value)
    {
        if (mIsLooping)
        {
            mLoopContent_Cell = Regex.Replace(mLoopContent_Cell, string.Format(@"#IF_{0}#((\S|\s)*)#END_{0}#", condition), (match) =>
            {
                if (value)
                {
                    return match.Groups[1].Value;
                }
                else
                {
                    return "";
                }
            });
        }
        else
        {
            mContent = Regex.Replace(mContent, string.Format(@"#IF_{0}#((\S|\s)*)#END_{0}#", condition), (match) =>
            {
                if (value)
                {
                    return match.Groups[1].Value;
                }
                else
                {
                    return "";
                }
            });
        }
    }

    /// <summary>
    /// 开始循环
    /// </summary>
    /// <param name="key"></param>
    public bool beginLoop(string key)
    {
        if (!Regex.IsMatch(mContent, string.Format(@"{0}(\s*(\S|\s)*)\s*{0}", key)))
            return false;

        mContent = Regex.Replace(mContent, string.Format(@"{0}(\s*(\S|\s)*)\s*{0}", key), (match) =>
        {
            mLoopTemplate_Cell = match.Groups[1].Value;
            return LOOPHOLDER;
        });

        mIsLooping = true;
        mLoopContent_All = "";
        mLoopContent_Cell = mLoopTemplate_Cell;
        return true;
    }

    /// <summary>
    /// 循环下一步
    /// </summary>
    public void nextLoop()
    {
        mLoopContent_All += mLoopContent_Cell;
        mLoopContent_Cell = mLoopTemplate_Cell;
    }

    /// <summary>
    /// 终止循环
    /// </summary>
    public void endLoop()
    {
        mIsLooping = false;
        mLoopContent_All = mLoopContent_All.Replace("\r\n\r\n", "\r\n");
        mLoopContent_All = mLoopContent_All.Replace("\r\n\r\n", "\r\n");
        mLoopContent_All = mLoopContent_All.Replace("\r\n\r\n", "\r\n");
        mLoopContent_All = mLoopContent_All.TrimStart("\r\n".ToCharArray());
        mLoopContent_All = mLoopContent_All.TrimEnd("\r\n".ToCharArray());
        setValue(LOOPHOLDER, mLoopContent_All);
        mLoopTemplate_Cell = "";
        mLoopContent_Cell = "";
        mLoopContent_All = "";
    }
}