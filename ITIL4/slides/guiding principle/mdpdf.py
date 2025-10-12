import markdown
from weasyprint import HTML
import tempfile
import os

def markdown_to_pdf(md_text, pdf_path, css_path=None):
    # Convert Markdown to HTML
    html_content = markdown.markdown(md_text)
    
    # Create a full HTML document
    full_html = f"""
    <!DOCTYPE html>
    <html>
      <head>
        <meta charset="utf-8">
        {f'<link rel="stylesheet" href="{css_path}">' if css_path else ''}
        <style>
          body {{
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 2cm;
          }}
          h1, h2, h3 {{
            color: navy;
          }}
          code {{
            background-color: #f4f4f4;
            padding: 2px 5px;
            border-radius: 3px;
          }}
          pre {{
            background-color: #f8f8f8;
            padding: 10px;
            border-radius: 5px;
            overflow-x: auto;
          }}
          pre code {{
            background-color: transparent;
            padding: 0;
          }}
        </style>
      </head>
      <body>
        {html_content}
      </body>
    </html>
    """
    
    # Generate PDF
    HTML(string=full_html).write_pdf(pdf_path)

# Read markdown content from file
with open("1.md", "r", encoding="utf-8") as f:
    markdown_text = f.read()  # Use read() instead of readlines()

# Convert to PDF
markdown_to_pdf(markdown_text, "1.md.pdf")

with open("2.md", "r", encoding="utf-8") as f:
    markdown_text = f.read()  # Use read() instead of readlines()
markdown_to_pdf(markdown_text, "2.md.pdf")

# with open("3.md", "r", encoding="utf-8") as f:
#     markdown_text = f.read()  # Use read() instead of readlines()
# markdown_to_pdf(markdown_text, "3.md.pdf")

# with open("4.md", "r", encoding="utf-8") as f:
#     markdown_text = f.read()  # Use read() instead of readlines()
# markdown_to_pdf(markdown_text, "4.md.pdf")