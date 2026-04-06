import os
import requests
import pandas as pd

pd.options.mode.chained_assignment = None

response = requests.get("https://leetcode.com/api/problems/all")
df_raw = pd.json_normalize(response.json()['stat_status_pairs'])

d = {1: 'Easy', 2: 'Medium', 3: 'Hard'}
df_raw['difficulty'] = df_raw['difficulty.level'].map(d)

columns = ['stat.frontend_question_id', 'stat.question__title', 'stat.question__title_slug', 'difficulty',
           'stat.total_submitted', 'stat.total_acs', 'paid_only']
df = df_raw[columns]

new_columns = ['question_id', 'question_title', 'question_title_slug', 'difficulty', 'answer_submitted',
               'answer_accepted', 'paywall']
df.columns = new_columns

df.set_index('question_id', inplace=True)
df.sort_index(inplace=True)

df['url'] = df['question_title_slug'].map(lambda slug: f'https://leetcode.com/problems/{slug}/')


def create_file(df, i):
    filepath = f'solutions/{i}-{df["question_title_slug"][i]}.cs'
    os.makedirs(os.path.dirname(filepath), exist_ok=True)
    open(filepath, 'a').close()


def get_row(df, i):
    return f"|{i}|[{df['question_title'][i]}]({df['url'][i]})|[C#](solutions/{i}-{df['question_title_slug'][i]}.cs)|{df['difficulty'][i]}|"


def get_commit_summary(df, i):
    return f"Add {i}-{df['question_title_slug'][i]}"


def update_readme(source, destination, rows, placeholder='$PLACEHOLDER$'):
    with open(source, 'rb') as f:
        content = f.read()
    rows = '\r\n'.join(rows)
    content = str(content, 'utf-8').replace(placeholder, rows)
    content = content.replace('\r\n', '\n')
    with open(destination, "w") as f:
        f.write(content)


if __name__ == "__main__":

    ids = [4, 1071, 1768, 5, 15, 3, 16, 18, 23, 25, 24, 33]

    create_files = True

    table = []
    for i in sorted(ids):
        table.append(get_row(df, i))
        if create_files:
            create_file(df, i)

    update_readme('source.md', 'README.md', table)

    print(get_row(df, ids[-1]))
    print(get_commit_summary(df, ids[-1]))
    pd.Series([get_commit_summary(df, ids[-1])]).to_clipboard(index=False, header=False)
