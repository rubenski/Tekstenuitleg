using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco;
using umbraco.NodeFactory;

namespace CursusIndex.util
{
    public class MacroUtil
    {
        // Renders inline macro's on fields that are themselves processef by a macro
        public static string RenderInlineMacros(string articleBody)
        {
            return RecursiveMacroLookupAndReplace(articleBody);
        }

        private static string RecursiveMacroLookupAndReplace(string input)
        {
            // Find the start point of the first inline macro
            int start = input.IndexOf("<?UMBRACO_MACRO");
            if (start > 0)
            {
                string endOfStatement = "/>";

                // Find the endpoint of the first inline macro
                int end = input.IndexOf(endOfStatement, start);

                // If the macro statement is cut in half, take it out
                if (end < 0)
                {
                    input = input.Substring(0, start);
                }else
                {
                    // Extract the inline macro statement
                    string macroStatement = input.Substring(start, end + endOfStatement.Length - start);
                    // Replace the macro statement with its output
                    input = input.Replace(macroStatement, library.RenderMacroContent(macroStatement, Node.getCurrentNodeId()));
                }
            }
            else
            {
                // No more macro statements? Return the result.
                return input;
            }
            // Look for more macro statements recursively.
            return RecursiveMacroLookupAndReplace(input);
        }
    }
}